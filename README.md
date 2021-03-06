# Team : Hackstreet Boys

## Category : The best enhancement to the Sitecore Admin (XP) for Content Editors & Marketers

## Module Name: Enhanced Package Designer:

This module was designed to enhance and extend the existing out of the box package designer (Items Statically). Offering users the ability to package items versions in **specific language/s** and the ability to **package item along with media item references and/or datasource references**.

The enhanced designer can be utilized to target items in a specific language/s By allowing users to capture a single, or multiple languages, for a given page rather than the need to package all languages for a given page. This reduces the risk that potential content authors face when migrating content between environments because language page versions that are not complete would have previously been packaged.

The enhanced designer also enables the user to package an item along with it's related/referenced media items and/or data sources. this will reduce the headache of trying to package page items and individually trying to indentify the referenced media/datasource items.

Features added in this module:
-	Ability to select language/s filter when i adding items statically 
-	Ability to add item with it's referenced media items 
-	Ability to add item with it's referenced media and/ datasource items

![Enhanced Package Designer](docs/images/Add-Static-Items-Highlights.png?raw=true "Enhanced Package Designer")

## Video link
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_

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

 ![Add with Media](docs/images/Add-With-Media.png?raw=true "Add with Media")

![Add-with-Media-and-Datasources](docs/images/Add-with-Media-and-Datasources.png?raw=true "Add-with-Media-and-Datasources")
 

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)

## Comments
If you'd like to make additional comments that is important for your module entry.
