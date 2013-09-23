Unity Extendable Defaults System
================================

Outline
-------

This set of source code provides support for flexible and extendable serialization of data as well as editors for each type of data. It will work within the current version of Unity3D Editor and Runtime. 

![Screenshot](/screenshot.png "UEDS Editor Window")

License
-------

The source code is provided under an MIT-License which is provided with the source code. Please refer to the included LICENSE file. 

Features
--------

- Flexible interface based IO-System
- Extendable serializers for custom data types
- Attribute based property and field serialization
- Editor window for easy editing of presets
- Customizable title and description for attributes in editor
- Customizable icon for types in editor
- Multiple presets per type

FAQ
---

_Why should I use it?_

Often you need some data in your classes that you don't want to store directly in your code. Instead you might want to make it accessible for game designers of other random people through a nice editor interface. However you might not want to use the Unity Editor's inspector to spare you of unnecessary game objects and maybe provide a more transparent and stream lined editing process for multiple instances. 

_When should I use it?_

With this system you can add some meta data to your classes and your game designers can create and edit instances of your classes with default preset data. For example you want to different types of collectables in your game with different values. When a prefab is not the way to go for you or your data actually comes from outside unity, you should definitely take a look at the system. 

_What can it actually do?_

By added meta data to your classes you can make properties and fields accessible in a nice editor window. Also you can extend this window with custom editors for your custom data types. You can then save your settings to file or load from them. Finally it can Deserialize Data for you and inject it to your class at runtime.

_Is there more help?_

Read the [getting started](Getting started.txt) for more info and have a look at the demo implementations 

- [Demo1.cs](ueds-unity/Assets/UEDS/Example/Demo1.cs)
- [Demo2.cs](ueds-unity/Assets/UEDS/Example/Demo2.cs)
- [Demo3.cs](ueds-unity/Assets/UEDS/Example/Demo3.cs)
- [ExampleClass.cs](ueds-unity/Assets/UEDS/Example/ExampleClass.cs)
- [ExampleClass2.cs](ueds-unity/Assets/UEDS/Example/ExampleClass2.cs)


___________


Attribution
-----------

The Icons used are provided by and can be downloaded free of charge at: 
http://www.famfamfam.com/lab/icons/
