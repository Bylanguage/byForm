# byForm, an online form designer application created in ByLanguage.

## Description
This is an online form designer, allow users to design a form using drag & drop operations.

All of the following application forms can be built in jsut one step: 
    Online-ordering, online-registration, online feedback collection, online questionnaires and online conferences arrangement...

Supporting inserting to any website using just one line of <script> tag, which cannot be achieved by current form-generators;
This project is written in the By Language, with a total of 4442 lines of codes, including Webside Javascript, Desktop-side c# client, Server-side c# program and server-side Java program, supporting MS sqlServer, MySql and Oracle as its Sql Engine. 

Online demo at: https://saas.baiyuyan.com/

Inject the following script tag into your html file to try this app：

<script>window.localStorage.setItem("_byt_saasid_storage", "0F8BFBFF000506570257810700030001")</script> <script src="https://saas.baiyuyan.com/form.js"> </script>

## Project Structure
This project is written in the By Language, the project includes one part of By Language Source code, and all the above platform sides code transpiled from the By-code base.(Web JavaScript, C# client, C# server, Java server, Sql database)

|--src  
&ensp;&ensp;|--lib&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp; (all referenced by libraries)  
&ensp;&ensp;|--byForm&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(the core byForm project folder)  
&ensp;&ensp;&ensp;&ensp;|--src&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(the By Laugnage code base, grouped by 'ku' (which is a basic packaging unit in the By Language, similar to a pagakge in Java))  
&ensp;&ensp;&ensp;&ensp;|--scene&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp; (the extra files used in multiple-platforms, such as using .html files in Web and using .resx files in client.)  
&ensp;&ensp;&ensp;&ensp;|--out&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(the output folder, containing all codes of transpiled program)  
&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;|-- database&ensp;&ensp;&ensp;&ensp;&ensp;(containing database SQL scripts)  
&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;|-- web&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(containing the outputed Web Application, including the corresponding JavaScript files)  
&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;|-- server&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(containing the stand-alone Server Application, including Java and C#)  
&ensp;&ensp;&ensp;&ensp;|--byForm.config&ensp;&ensp;(the project configure file, containing information about ku reference and project deployment.)

(More information about our Project structure is at out main site)

## Programming and Testing
You can directly use the transplied program in the 'out' folder, 
Or you can download our By Language IDE at https://www.baiyuyan.com/   https://www.baiyuyan.com/download_en.html

Our IDE is totally free, supporting code-analysis, intellisense, auto-complete and auto-deployment.
You can easily get your own out-folders in just one single 'transpile' in our IDE, creating your own JavaScript, C#, Java and Sql outputs.



## Toturial
Toturial videos at:  https://www.baiyuyan.com/player.html?id=18

Donations


# 拜语言开发的在线表单设计器

## 介绍

表单设计器允许直接使用拖拽进行操作，可以一站式制作：在线订单、在线报名、在线登记、在线收集意见反馈、调查统计、会议预约等。

通过插入一行  `<script>`  标签，就可以集成到任意的网页中运行， 这是现在主流的在线表单程序做不到的。 

本项目是使用拜语言开发的，共计 4442 行代码，包括 JavaScript 开发的网页端和独立的 C# 服务端、Java 服务端，两者任选其一部署。并且支持链接 MS sqlServer, MySql 或 Oracle 数据库。

在线体验网址：https://saas.baiyuyan.com/

插入以下代码即可运行：

<script>window.localStorage.setItem("_byt_saasid_storage", "0F8BFBFF000506570257810700030001")</script> <script src="https://saas.baiyuyan.com/form.js"> </script>

## 项目架构
本项目主要由拜语言开发，以上所有平台端代码都是从拜语言源代码使用转译而得到的。(Web JavaScript, C# server, Java server, Sql database)

|--src  
&ensp;&ensp;|--lib&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp; (所有的引用库)  
&ensp;&ensp;|--byForm&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(项目源代码文件夹)  
&ensp;&ensp;&ensp;&ensp;|--src&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(拜语言代码库，按 “ku” 分组（库是拜语言中的一个基本封装单元，类似于 Java 中的 pagadge))  
&ensp;&ensp;&ensp;&ensp;|--scene&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp; (在多个平台中使用的额外文件，例如在 Web 中使用 .html 文件和在客户端中使用 .resx 文件。)  
&ensp;&ensp;&ensp;&ensp;|--out&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(整体的输出文件夹，包含转译后的所有源代码)  
&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;|-- database&ensp;&ensp;&ensp;&ensp;&ensp;(转译后的数据库创建脚本)  
&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;|-- web&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(转译后的 Web 应用程序，包括相应的 JavaScript 文件)  
&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;|-- server&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;&ensp;(转译后的独立服务器应用程序，包括 Java 和 C# 代码)  
&ensp;&ensp;&ensp;&ensp;|--byForm.config&ensp;&ensp;&ensp;(项目配置文件，包含引用库和项目部署信息)

(有关我们项目结构的更多信息，请访问主网站)

## 使用说明

你可以直接使用 “\out” 文件夹内的程序，或者下载拜语言的 IDE 重新转译。拜语言的 IDE 下载地址在：https://www.baiyuyan.com/， 
https://www.baiyuyan.com/download_en.html 。

IDE 是完全免费的，并且它支持代码分析，智能提示，自动编译，自动部署。你可以仅通过一次转译就轻易获取属于自己的输出文件夹，其中包含 JavaScript，C#，Java 和 Sql 程序。

## 教程
完整视频教程:  https://www.baiyuyan.com/player.html?id=18

此致
