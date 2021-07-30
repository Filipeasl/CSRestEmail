# csrestcrud
&nbsp;&nbsp;&nbsp;A C#, .NET Core based REST E-mail sending service using <a href="https://github.com/lukencode/FluentEmail">FluentEmail</a>.<br/>
&nbsp;&nbsp;&nbsp;Some examples of SMTP server requires a secure connection. Gmail is one of them. Therefore, you have to enable Less Secure Sign-In (or Less secure app access) in your google account.

## deployt to production
run " dotnet publish " in dotne cli, then upload the contents of .\CSRestEmail\CSEmail\bin\Debug\net5.0\publish\ int your hosting file manager.