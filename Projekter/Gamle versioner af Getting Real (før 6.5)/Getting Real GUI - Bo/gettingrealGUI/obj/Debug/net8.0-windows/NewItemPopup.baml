   M S B A M L   `   `   `  ����  gettingrealGUI    GettingReal.NewItemPopup   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression.blend/2008     5   	   Emc6http://schemas.microsoft.com/markup-compatibility/2006     5   	     � Title$   Tilføj ydelser til tilbud��5   	   $	��575��6+   $	��400��68    � 
ResizeMode$ NoResize=�5   	   .��5      �� $��10q�6   .+�5	   
   �� $!��Vælg en ydelse fra listen:��6   $��2,0,0,0q�65   �� 5
   
   -   5         ��Name$ lstSelection��5
       �� SelectionMode$ Single=�6(   $	��300��6?   $	��350��6L   �� 5   
   $��Vælg prisniveau:��6   $��2,0,0,0q�6+   �� 5   
   -   5         ��Name$ 
cbDropdown��5      $	��350��6'   .@�5      �� $	��Lav��6   �� 5      $��Middel��6   �� 5      $
��Høj��6   5      �� 5   
   $ ��Indtast rabat % (valgfri):��6   $��2,0,0,0q�65   �� 5   
   -   5         ��Name$ txtRabat��5      $	��350��6$   $�� ��60   �� 5   
   $/��)Indtast estimeret antal timer for opgave:��6   $��2,0,0,0q�6D   �� 5   
   -   5        $ txtTimeEstimat��5      $	��350��6*   $�� ��66   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5      �� -   5         ��Name$ btnAddNewItemOK��5      $��OK��6.   $��60��6;   $��5,15,5,5q�6F   6X   �� 5      -   5        $ btnAddNewItemFortryd��5      $��Fortryd��63   $��60��6E   $��5,15,5,5q�6P   6b   5      5      5      