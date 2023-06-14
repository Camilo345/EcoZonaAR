using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using System;
using System.Threading;

public class enviarEmail : MonoBehaviour
{

    string filepat="";

    bool triggerResultEmail = false;
    bool resultEmailSucess;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enviarCorreo(string filepath)
    {
        filepat = filepath;
        Invoke("llamarEnviar",0.1f);
    }

    void llamarEnviar()
    {
        StartCoroutine(enviar(filepat));
    }

    IEnumerator enviar(string filepath)
    {
        yield return new WaitForSeconds(.1f);
          MailMessage mail = new MailMessage();
          SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
          mail.From = new MailAddress("juancamilobola354@gmail.com");
          mail.To.Add("jcamilob3456@gmail.com");
          mail.To.Add("juanc.kaleidolab@gmail.com");
          mail.Subject = "Fotos ZonaEco";
          mail.Body = "Foto ZonaEco";

          System.Net.Mail.Attachment attachment;
          attachment = new System.Net.Mail.Attachment(filepath);
          mail.Attachments.Add(attachment);

          SmtpServer.Port = 587;
          SmtpServer.Credentials = new System.Net.NetworkCredential("juancamilobola354@gmail.com", "ldzzsvqditlppxak");
          SmtpServer.EnableSsl = true;

          SmtpServer.SendAsync(mail,"");
      //  StartCoroutine(Send(filepat, SendCompletedCallback));
        
    }

    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled || e.Error != null)
        {
            print("Email not sent: " + e.Error.ToString());

            resultEmailSucess = false;
            triggerResultEmail = true;
        }
        else
        {
            print("Email successfully sent.");

            resultEmailSucess = true;
            triggerResultEmail = true;
        }
    }

    public IEnumerator Send( string filepath, Action<object, AsyncCompletedEventArgs> callback)
    {
        yield return new WaitForSeconds(0.1f);
        try
        {
            float result = 0;
            var hilo = new Thread(() => result = ReadDataFromIO());
            hilo.Start();
            SmtpClient mailServer = new SmtpClient("smtp.gmail.com", 587);
            mailServer.EnableSsl = true;
            mailServer.Credentials = new NetworkCredential("juancamilobola354@gmail.com", "ldzzsvqditlppxak") as ICredentialsByHost;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                return true;
            };

            MailMessage msg = new MailMessage("juancamilobola354@gmail.com", "jcamilob3456@gmail.com");
            msg.Subject ="Fotos ZonaEco";
            msg.Body = "FotoZonaEco";
            if (filepath != null && !filepath.Equals(""))
                if (File.Exists(filepath))
                    msg.Attachments.Add(new Attachment(filepath));

            mailServer.SendCompleted += new SendCompletedEventHandler(callback);
            mailServer.SendAsync(msg, "");

            hilo.Join();
            Debug.Log("SimpleEmail: Sending Email.");
        }
        catch (Exception ex)
        {
            Debug.LogWarning("SimpleEmail: " + ex);
            callback("", new AsyncCompletedEventArgs(ex, true, ""));
        }

    }

    static float ReadDataFromIO()
    {
        // Estamos simulando una E/S poniendo el hilo actual en suspensión.
        Thread.Sleep(5000);
        return 10;
    }

}
