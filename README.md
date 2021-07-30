# csrestcrud
&nbsp;&nbsp;&nbsp;A C#, .NET Core based REST E-mail sending service using <a href="https://github.com/lukencode/FluentEmail">FluentEmail</a> and <a href="https://swagger.io/">Swagger</a>.<br/>
&nbsp;&nbsp;&nbsp;Some examples of SMTP server requires a secure connection. Gmail is one of them. Therefore, you have to enable Less Secure Sign-In (or Less secure app access) in your google account.

## deployt to production
&nbsp;&nbsp;&nbsp;Run <code>dotnet publish</code> in dotne cli, then upload the contents of .\CSRestEmail\CSEmail\bin\Debug\net5.0\publish\ int your hosting file manager.

## how to use it
&nbsp;&nbsp;&nbsp;Open project folder, type <code>dotnet run</code> in dotnet cli, access https://localhost:5001/swagger/index.html. Then inside of the post json parameters, type your entries as it follows:<br/><br/>
The default port is 587.<br/>
<pre>
{
  "id": 0,
  "eSmtpHost": "smtp server domain",
  "eName": "Your name",
  "eLogin": "your e-mail login",
  "ePassword": "your e-mail password",
  "eTo": "receiver e-mail address",
  "eSubject": "e-mail subject",
  "eBody": "your e-mail message"
}
</pre>
<br/><br/>
For example:
<br/><br/>
<pre>
{
  "id": 0,
  "eSmtpHost": "smtp-mail.outlook.com",
  "eName": "Filipe",
  "eLogin": "filipel@live.com",
  "ePassword": "My e-mail password",
  "eTo": "filipelas46@gmail.com",
  "eSubject": "Testing",
  "eBody": "Testing email 123"
}
</pre>
