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
