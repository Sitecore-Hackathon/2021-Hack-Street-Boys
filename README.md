# Team : Hackstreet Boys

## Category : The best enhancement to the Sitecore Admin (XP) for Content Editors & Marketers

## Module Name: Enhanced Package Designer

**Enhanced Package Designer** 
> Empower Content Authors to better control the content packaging using Package Designer.

This module was designed to enhance and extend the existing out of the box package designer (Items Statically). Offering users the ability to package items versions in **specific language/s** and the ability to **package item along with media item references and/or datasource references**.

The enhanced designer can be utilized to target items in a specific language/s By allowing users to capture a single, or multiple languages, for a given page rather than the need to package all languages for a given page. This reduces the risk that potential content authors face when migrating content between environments because language page versions that are not complete would have previously been packaged.

The enhanced designer also enables the user to package an item along with it's related/referenced media items and/or data sources. this will reduce the headache of trying to package page items and individually trying to identify the referenced media/datasource items.

Features added in this module:
-	Ability to select language/s filter when i adding items statically 
-	Ability to add item with it's referenced media items 
-	Ability to add item with it's referenced media and/ datasource items

![Enhanced Package Designer](docs/images/Add-Static-Items-No-Highlight.png?raw=true "Enhanced Package Designer")

## Video link
⟹ Provide a video highlighting your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

⟹ [Replace this Video link](#video-link)


## Pre-requisites and Dependencies

 - SXA (Only required for the demo, however the module itself can be installed without SXA)

## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

 - Download and install fresh instance of (XM) [Sitecore 10.1](https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/101/Sitecore_Experience_Platform_101.aspx)
 - Install SXA module (needed for testing - module is not specific for SXA, it works with non-SXA sites as well).
 - Install Enhanced Package Designer-1.0.zip package ([Can be found here](https://github.com/Sitecore-Hackathon/2021-Hack-Street-Boys/blob/main/sc.packages/Enhanced%20Package%20Designer-1.0.zip))
 - Install HackStreetBoys Demo Site-1.0.zip ([Can be found here](https://github.com/Sitecore-Hackathon/2021-Hack-Street-Boys/blob/main/sc.packages/HackStreetBoys%20Demo%20Site-1.0.zip))
 

## Usage instructions

The Sitecore Enhanced Package Designer is easy to use, you need to start with the following:
 1. Got to /sitecore and login into desktop
 2. Click Sitecore start menu, then **Development Tools** > **Package Designer**
 3. From the menu on top, click Items Statically

see the following screenshots:

 ![Package Designer](docs/images/open-package-designer.png?raw=true "Package Designer")
 
 ![Add Static Items](docs/images/Add-Static-Items.png?raw=true "Add Static Items")


Once you have the click items statically dialog, you will have the following new features:

### Package Specific Item Language(s)

A new language checkbox list field has been added, where the Content Author can choose the languages that need to be packaged for the select item, following is a screenshot for the dialog:

Instructions:
1. From the Checkbox list, select the targeted language(s).
2. Select your targeted item/page
3. Click any of the 4 Add options you have as needed. 

 ![Language Selection](docs/images/Language-Selection.png?raw=true "Language Selection")


### Add with Media

How many times you needed to package items from lower environment(s) and you missed related media items (images, pdfs, word...etc)? A lot, right? using the new cool package designer enhancement/feature, you can now be sure that your item/page related media items are being packaged, a new (Add with Media) option has been added, where you can use to include the related media items for your current select item, following is a screenshot for the dialog:

Instructions:
1. Select your targeted item/page
2. Click (Add with Media) link/button. 

![Add with Media](docs/images/Add-With-Media.png?raw=true "Add with Media")


### Add with Media and Datasources

Similar to the previous use case, if you are packaging a page, you need the page related media items and rendering data sources to be included automatically, without the need to manually go through all related items, this is now possible with the (Add with Media and Datasources) enhancement that this module add to the package designer. following is a screenshot for the dialog:

Instructions:
1. Select your targeted item/page
2. Click (Add with Media and Datasources) link/button.

![Add-with-Media-and-Datasources](docs/images/Add-with-Media-and-Datasources.png?raw=true "Add-with-Media-and-Datasources")
 

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
