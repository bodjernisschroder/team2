   M S B A M L   `   `   `  ����F  BWPFAndMVVM2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFAndMVVM2WPFAndMVVM2  5   	       WPFAndMVVM2.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFAndMVVM2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��250 �6   $	��200��6+   �� 5      $��5 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $	��10* �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ 	myListBox��5      $��0��6)   ��66   �� *	PersonsVM+ �� SelectedItem 6X   �� *SelectedPerson+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� ��6$   �� *	FirstName+�� 5      ��6$   �� *
LastName+5      5      5      �� 5      $ 
Horizontal=�6   $��1��62   .+�5      �� -   5         ��Name$ btnNewPerson��5      $��
New person��6/   $��0,0,0,0q�6D   $	��Top=�6U   $��40��6m   $	��125��6y   $��2��6�   ��6�   �� *NewCmd+��6�   �� �� 5       -   5        $ btnDeletePerson��5       $��Delete person��62   $
��Left=�6J   $��0,0,0,0q�6e   $	��Top=�6v   $��40��6�   $	��125��6�   ��6�   �� *	DeleteCmd+��6�   �� 5!      5"      �� 5$   
   $��5��6   $��1��6!   $��Stretch=�61   � 5%   
   $��2��6   .+�5&      �� $��20��6e   $	��Top=�6q   $��170,62,171,0q�6�   ��6   �� *SelectedPerson.FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5'      $��20��6d   $��170,109,171,0q�6p   $	��Top=�6�   ��6   �� *SelectedPerson.LastName+$ PropertyChanged=�6�   �� 5(      $��20��6_   $��170,158,171,0q�6k   $	��Top=�6�   ��6   �� *SelectedPerson.Age+$ PropertyChanged=�6�   �� 5)      $��20��6a   $��170,204,171,0q�6m   $	��Top=�6�   ��6   �� *SelectedPerson.Phone+$ PropertyChanged=�6�   �� 5*      $��
FirstName:��6   $
��Left=�6)   $��	67,59,0,0q�6D   $	��Top=�6W   �� 5+      $��	LastName:��6   $
��Left=�6(   $��
67,103,0,0q�6C   $	��Top=�6W   $��66��6o   �� 5,      $
��Age:��6   $
��Left=�6#   $��
67,152,0,0q�6>   $	��Top=�6R   �� 5-      $��Phone:��6   $
��Left=�6%   $��
67,204,0,0q�6@   $	��Top=�6T   5.      5/      50      