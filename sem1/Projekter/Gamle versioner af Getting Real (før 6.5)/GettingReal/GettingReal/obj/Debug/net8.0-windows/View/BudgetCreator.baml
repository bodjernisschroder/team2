   M S B A M L   `   `   `  ����F  BGettingReal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GettingRealGettingReal  5          GettingReal.BudgetCreator   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:GettingReal     5        � 	Resources  5
         	IconStyle �� 
TargetType �� Property �� Value �� 
TargetType��%6  &	        �� 5   
   " ��6"   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 15(�6)   �� 5       � ��$ 	Helvetica)�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 40��6'   �� 5       � ��$ 40��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Center=�6+   $��Center=�6H   5      5      5      5       .��5"      � .+�5#   
   �� $��Center=�6   $��Center=�62   
�������.+�5$      ]� $	��500��6   $��40��6$   ���#282828.+�5&      �� -   5        $��btnQuestion��5&      $
��Left=�6,   $	��❓��6B   #��[  6N   6q   �� 5'      -   5        $��btnNewBudget��5'      $��Right=�6-   $	��➕��6D   #��[  6P   6s   �� 5(      -   5        $��btnSaveBudget��5(      $��Right=�6.   $
��💾��6E   #��[  6R   6u   �� 5)      -   5        $��btnLoadBudget��5)      $��Right=�6.   $
��📁��6E   #��[  6R   6u   �� 5*      $��Right=�6   $��0��6/   5,      �� 5-      ���#282828$��3q�6+   $	��500��6?   $	��375��6K   ._�5.      &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDataGrid��5.         AutoGenerateColumns$ False��6/      SelectionUnit$
 Cell=�6s      HeadersVisibility$ Column=�6�   	   
IsReadOnly$	 False��6�   ��6K   �� *Budget.Products+
   Columns
 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ Ydelse��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Name+  51      $
 Pris��6-   $ 75 6;    6F   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  53      $ Delete��61   $ 45 6A      CellTemplate 54      �� 55   "   .R�56   &   �� -   5        $	��❌��56   -   
���  ��$��15��6J   $��15��6V   $��10(�6a   #��[  6o   6�   57   #   59      5;      5=      ]� 5>      $	��500��6   $��40��6$   ���#282828.+�5A      �� -   5        $��lblTotalPris��5A      $��Right=�6,   $��0,0,5,0q�6C   
�������$��18(�6g   $��0,00 kr.��6u   $��Center=�6�   $��Center=�6�   �� 5C      $��Right=�6   $��0��6/   5E      5F      5G      5H      