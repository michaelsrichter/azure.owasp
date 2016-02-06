# OWASP Security wit Azure

Are you responsible for web applications? 
Are you familiar with OWASP and the OWASP Top 10 Vulnerabilities?
You can use Microsoft Azure to protect your web applications.

This repo contains sample code that illustrates some of the security
features of Azure and how to implement them. 

#### Prerequisites

* These samples were built with Visual Studio 2015, but it's not required for building or deploying these solutions.
* The code samples require at least .NET 4.5.2
* To deploy, you will need an Azure subscription.
* To deploy the Barracuda WAF project you will need an Azure subscription with a Credit Card on file.
* You can deploy solutions with Visual Studio Web Publish, Powershell or FTP.
* The NodeJS projects require nodejs running locally to test. To open the projects in Visual Studio, you need the NodeJs Tools for Visual Studio plugin.


### azure.owasp.modsecurity

The most important component of web application security is a Web Application Firewall (WAF).
A WAF sits between your application and the internet, inspecting traffic and acting on
potential threats. For web apps running on Azure's App Services PaaS solution, adding a WAF is easy.
Each Azure Web App comes with modsecurity. Modsecurity is a flexible open-source WAF that uses simple text-based rules for configuration.

This project shows you
how simple it is to get this working with your app.

### azure.owasp.waf-lb-arm

modsecurity is nice because it's open-source, free and comes integrated with all Azure PaaS web apps. What if you are not running in PaaS but in Azure Iaas?
Sometimes you need an industrial strength WAF solution that can cover your VM based applications. The Azure Marketplace
has several commercial WAF solutions available. These solutions often come with easier-to-use tooling but powerful features and reporting.

This project is a collection of Azure ARM templates that compose a load balanced Barracuda WAF solution. Use it to protect your own VMs!

### azure.owasp.waf.app

Use this project with *azure.owasp.waf-lb-arm* to learn how to protect a VM-based web app with the Barracuda WAF!

This project requires the NodeJS Tools for Visual Studio.

### azure.owasp.web.adgroups

This is a fun project that illustrates how to use Azure AD groups to limit access to different parts of your web application.
It also explorers Azure Active Directory and the advanced features you can use when leveraging Azure's Identity-as-a-Service (IdaaS) offering.

### azure.owasp.web.node.settings

It's dangerous to put sensitive data into configuration files. You don't want configuration files to contain passwords or secret keys.
Even for dev/test scenarios, it's a good habit not to put keys in your config files. That behavior can make its way into production. 
You don't want production keys in config files checked into source code where all the developers, testers and release teams can see it.

So what can you do? 
Use Azure's Application Settings in the App Service PaaS offering. 
The keys go directly into the Azure Portal where you can restrict access to only the people that manage your production environments. Apps hosted in Azure will read the keys from Azure and not from configuration!

This project requires the NodeJS Tools for Visual Studio.

### azure.owasp.web.notsecure

Do you have a website with sensitive data and no way to secure access to it? You can easily add authentication to your website when it's hosted in Azure Web Apps PaaS! Read through this project to see how easy it is.

### Copyright and License
- Copyright &copy; Microsoft Corporation 2016
- Released under the MIT License (MIT)
- Please see LICENSE for more information.