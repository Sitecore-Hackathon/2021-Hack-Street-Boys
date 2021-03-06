# Hackathon Submission Entry form

> __Important__  
> 
> Copy and paste the content of this file into README.md or face automatic __disqualification__  
> All headlines and subheadlines shall be retained if not noted otherwise.  
> Fill in text in each section as instructed and then delete the existing text, including this blockquote.

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team : Hackstreet Boys

## Category : The best enhancement to the Sitecore Admin (XP) for Content Editors & Marketers

## Module Name: Enhanced Package Designer:

  This module enhances the existing package designer by providing additional options when using **items statically** option
  - allowing content authors to package items in specific language, This will help to package only content that is ready in specific language.
  - Adding option to add single item with all media items that the item is referencing.
  - Adding option to add single item with all datasource items that the item is referencing.


## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)



## Pre-requisites and Dependencies

 - None

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

 - Download [Sitecore 10.1 Graphical setup package for XM Scaled](https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/101/Sitecore_Experience_Platform_101.aspx)
 - Run the setup.exe, with **Installation/Solution Prefix** = hackstreetboys
 - Clone the repository locally
 

## Usage instructions

 1. Got to /sitecore and login into desktop
 2. Click Sitecore start menu, then **Development Tools** > **Package Designer**
 3. From the menu on top, click Items Statically
 4. In the Language dropdown, select english
 5. Navigate to sitecore/content/home/demo/multi-lingual , this item has english and danish versions, but we only want the english version
 6. Click Add Item, then click next, name your source "only english"
 7. From the menu on top, click Items Statically
 8. Leave Language dropdown empty
 9. navigate to sitecore/content/home/demo/page-with-media
 10. click Add Item with Media, then click next, name your source "item with media"
 11. From the menu on top, click Items Statically
 12. Leave Language dropdown empty
 13. navigate to sitecore/content/home/demo/page-with-datasources
 14. Click Add Item with datasource, then click next, name your source "item with datasources"
 15. Click on "only english" source and verify that only english version is added
 16. click on "item with media" and verify that the item was added with all referenced media items
 17. click on "item with datasources" and verify that item was added with all referenced media items

 
 

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.
