# asp.net-mvc-contact-form
Simple ASP.NET MVC application that includes a contact form that will send an email to a configured email address.

If contact form is not the page that loads when debugging, simple navigate to **~/Contact/Index</strong>**.

## Configuring SMTP client.
In order for the form to successfully send the data, the following elements in the Web.config need to be edited accordingly.
```XML
<appSettings>
	<add key="ContactSMTPServer" value="" />
	<add key="ContactSMTPPort" value="" />
	<add key="ContactSMTPUser" value=""/>
	<add key="ContactSMTPPassword" value=""/>
	<add key="ContactSMTPEnableSSL" value=""/> <!-- true or false-->
</appSettings>
```
