package com.unity3d.player;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageManager;
import android.os.Bundle;
import android.webkit.WebResourceError;
import android.webkit.WebResourceRequest;
import android.webkit.WebView;
import android.webkit.WebViewClient;

public class PrivacyActivity extends Activity implements DialogInterface.OnClickListener {
    boolean useLocalHtml = true;
    String privacyUrl = "https://blog.csdn.net/qq_61885864?spm=1011.2415.3001.5343";
    final String htmlStr = "��ӭʹ�ñ���Ϸ����ʹ�ñ���Ϸǰ����������Ķ������<a href=\"https://blog.csdn.net/qq_61885864?spm=1011.2415.3001.5343\">���û�Э�顷</a>��<a href=\"https://blog.csdn.net/qq_61885864?spm=1011.2415.3001.5343\">����˽���ߡ�</a>����\n" +
            "��˽����Ƕ��ڸ�����Ϣ�Ĵ�������Ȩ�������Ŀ�ģ��ر�������ע��ǰ��Э���й���\n" +
            "��������������Σ���������Ȩ������������������ʽ��˾����Ͻ�����ݡ����ǽ���\n" +
            "��������ط��ɷ������˽�����Ա������ĸ�����˽��Ϊȷ��������Ϸ���飬���ǻ������������±�ҪȨ�ޣ�����ѡ��ͬ����߾ܾ����ܾ����ܻᵼ���޷����뱾��Ϸ��ͬʱ�����ǻ���ݱ���Ϸ����ع��ܵľ�����Ҫ��������Ǳ�Ҫ��Ȩ�ޣ�����ѡ��ͬ����߾ܾ����ܾ����ܻᵼ�²�����Ϸ�����쳣�����б�ҪȨ�ް������豸Ȩ��(��Ҫ)����ȡΨһ�豸��ʶ (AndroidID��mac)�������ʺš�����ͻָ���Ϸ���ݣ�ʶ���쳣״̬�Լ��������缰��Ӫ��ȫ���洢Ȩ��(��Ҫ)���������Ĵ洢�ռ䣬�Ա�ʹ���������ز��������ݡ�ͼƬ�洢���ϴ�������������Ϣ�����д��ϵͳ����־�ļ�������\n";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        ActivityInfo actInfo = null;
        try {
            //��ȡAndroidManifest.xml���õ�Ԫ����
            actInfo = this.getPackageManager().getActivityInfo(getComponentName(), PackageManager.GET_META_DATA);
            useLocalHtml = actInfo.metaData.getBoolean("useLocalHtml");
            privacyUrl = actInfo.metaData.getString("privacyUrl");
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
        }

        //����Ѿ�ͬ�����˽Э����ֱ�ӽ���Unity Activity
        if (GetPrivacyAccept()){
            EnterUnityActivity();
            return;
        }
        ShowPrivacyDialog();//������˽Э��Ի���
    }

    @Override
    public void onClick(DialogInterface dialogInterface, int i) {
        switch (i){
            case AlertDialog.BUTTON_POSITIVE://���ͬ�ⰴť
                SetPrivacyAccept(true);
                EnterUnityActivity();//����Unity Activity
                break;
            case AlertDialog.BUTTON_NEGATIVE://����ܾ���ť,ֱ���˳�App
                finish();
                break;
        }
    }
    private void ShowPrivacyDialog(){
        WebView webView = new WebView(this);
        if (useLocalHtml){
            webView.loadDataWithBaseURL(null, htmlStr, "text/html", "UTF-8", null);
        }else{
            webView.loadUrl(privacyUrl);
            webView.setWebViewClient(new WebViewClient(){
                @Override
                public boolean shouldOverrideUrlLoading(WebView view, String url) {
                    view.loadUrl(url);
                    return true;
                }

                @Override
                public void onReceivedError(WebView view, WebResourceRequest request, WebResourceError error) {
                    view.reload();
                }

                @Override
                public void onPageFinished(WebView view, String url) {
                    super.onPageFinished(view, url);
                }
            });
        }

        AlertDialog.Builder privacyDialog = new AlertDialog.Builder(this);
        privacyDialog.setCancelable(false);
        privacyDialog.setView(webView);
        privacyDialog.setTitle("�û���������˽");
        privacyDialog.setNegativeButton("ȡ��",this);
        privacyDialog.setPositiveButton("ȷ��",this);
        privacyDialog.create().show();
    }
//����Unity Activity
    private void EnterUnityActivity(){
        Intent unityAct = new Intent();
        unityAct.setClassName(this, "com.unity3d.player.UnityPlayerActivity");
        this.startActivity(unityAct);
    }
//����ͬ����˽Э��״̬
    private void SetPrivacyAccept(boolean accepted){
        SharedPreferences.Editor prefs = this.getSharedPreferences("PlayerPrefs", MODE_PRIVATE).edit();
        prefs.putBoolean("PrivacyAccepted", accepted);
        prefs.apply();
    }
    private boolean GetPrivacyAccept(){
        SharedPreferences prefs = this.getSharedPreferences("PlayerPrefs", MODE_PRIVATE);
        return prefs.getBoolean("PrivacyAccepted", false);
    }
}