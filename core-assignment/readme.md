The files contained in this folder make up several components of a core assignment. This includes page type generated class files, and examples for Content Tree-based Routing (basic and advanced), and Content Tree-based Routing page template examples (basic and advanced w/ service). I will do my best to state which files are used for which example. Some files may be used for more than one example.

Please note that generated classes are based off page types with only the default fields, and a single additional text box field.

Global files:
* \_Layout.cshtml

Basic content tree routing:
* custom_Hello.cshtml

Advanced content tree routing:
* CustomGoodbye.cshtml
* GoodbyeViewModel.cs
* GoodbyeController.cs
* Goodbye.generated.cs
* GoodbyProvider.generated.cs

Basic page template:
* \_Insult.cshtml
* InsultTemplateProperties.cs
* ComponentRegister.cs

Advanced page template w/ service:
* ComplimentTemplateService.cs
* Insult.generated.cs
* InsultProvider.generated.cs
* \_Compliment.cshtml.cs
* ComplimentTemplateProperties.cs
* ComplimentController.cs
* Startup.cs (to initiate service)
