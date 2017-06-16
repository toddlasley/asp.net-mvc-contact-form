# asp.net-mvc-contact-form
Simple ASP.NET MVC application that includes a contact form that will send an email to a configured email address.

If contact form is not the page that loads when debugging, simple navigate to <strong>~/Contact</strong> or set <strong>~/Views/Contact/Index.cshtml</strong> as the startup page.

<h3>Configuring SMTP client.</h3>
In order for the form to successfully send the data, the following elements in the Web.config need to be edited accordingly.
<pre>
	<add key="ContactSMTPServer" value="" />
	<add key="ContactSMTPPort" value="" />
	<add key="ContactSMTPUser" value=""/>
	<add key="ContactSMTPPassword" value=""/>
	<add key="ContactSMTPEnableSSL" value=""/> <!-- true or false-->
</pre>
