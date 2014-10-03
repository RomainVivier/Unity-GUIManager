# What does this do ?

This is a simple and easy to use GUIManager system for Unity3D. It allows you to create classes to draw GUIs independently from one each another and to handle them with ease.

# How do I use it ?

Here is the two classes i use to create and handle easy GUIs:

1. BasicGUI

  It is an abstract class you will have to extend to create your GUIs. it is compose of different methods such as :

   * Init (called at the start of the GUIManager) *virtual*
   * DrawInterface (where you will define your GUI) *abstract*
   * OnShow (when your GUI switch from hide to show) *virtual*
   * OnHide (when your GUI switch from show to hide) *virtual*
   * Destroy (when your GUI class is detroy) *virtual*


The other class is name GUIManager

2. GUIManager

  It is the core that will handle every developer class that inherits BasicGUI. It is a singleton so you don't have to instantiate it in your Unity3D scene, you just have to call it with `GUIManager.Instance` and it will instantiate himself.
  
  To use it you first have to plug you GUIs into it. To do so, in the InitManager method, you just to add GUIs using this line :
  `_guiList.Add("GUIKeyName", new aClassExtendingBasicGUI());`
  
  Once you have plug your GUIs you will be able to use them with the following members, methods of GUIManager : 
  
   * CurrentGUI (return the id of the current GUI drawn by GUIManager) *member*
   * Back (change to the last GUI) *method*
   * Hide (hide GUI) *method*
