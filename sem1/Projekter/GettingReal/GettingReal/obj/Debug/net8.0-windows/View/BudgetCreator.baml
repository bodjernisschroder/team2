   M S B A M L   `   `   `  ����  GettingReal    GettingReal.BudgetCreator   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	         	IconStyle �� 
TargetType �� Property �� Value  SansSemiBold �� 
TargetType �� Triggers P� Property P� Value��%�  &	        7  �� 5   
   " ��6"   .�5      ��  � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 15(�6)   �� 5       � ��8   6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 40��6'   �� 5       � ��$ 40��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��Center=�6+   $��Center=�6H   5      5       5      P� 5       � {�$ False��6/   . �5      ��  � ��
 �����63   5       5"      5%      .��5(      � .+�5)   
   �� $��Center=�6   $��Center=�62   
�������.+�5*      ]� $	��500��6   $��40��6$   ���#282828.+�5,      �� $��Prisniveau:��6   
�������$��14(�6A   $��Center=�6O   �� 5-      -   5        $��btnPriceLevelLow��5-      $
��Left=�61   $��1��6G   #��[  6S   $��25��6�   �� 5.      -   5        $��btnPriceLevelMedium��5.      $
��Left=�64   $��2��6J   #��[  6V   $��25��6�   �� 5/      -   5        $��btnPriceLevelHigh��5/      $
��Left=�62   $��3��6H   #��[  6T   $��25��6�   ${�False��6�   �� 50      -   5        $��CheckBox��50      $��20��6.   $
��Left=�69   $��Center=�6O   $��10,0,0,0q�6j   6�   �� 51      $��Lås Tilpassede Priser��6   
�������$��14(�6K   $��Center=�6Y   �� 52      -   5        $��btnNewBudget��52      $��Right=�6-   $	��➕��6D   #��[  6P   $��40��6�   �� 53      -   5        $��btnSaveBudget��53      $��Right=�6.   $
��💾��6E   #��[  6R   $��40��6�   �� 54      -   5        $��btnLoadBudget��54      $��Right=�6.   $
��📁��6E   #��[  6R   $��40��6�   �� 55      -   5        $��btnCopyToClipboard��55      $��Right=�63   $
��📋��6J   #��[  6W   $��40��6�   �� 56      $��Right=�6   $��0��6/   57      �� 58      ���#282828$��3q�6+   $	��500��6?   $	��325��6K   ._�59      &   System.Windows.Controls.DataGrid  -	   5          Name$ 
myDataGrid��59      	   AutoGenerateColumns$	 False��6q   
   SelectionUnit$

 Cell=�6�      HeadersVisibility$ Column=�6�   $��0,0,0,-3q�6�   ��6�   �� *
Products+   Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ Ydelse��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Name+  5<      $ Time Estimat��6-   $	 100 6C    6O   �� *TimeEstimate+  5=      -
   5        PriceColumn��$
 Pris��5=   B   $ 75 6P    6[   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  5>      $ Delete��61   $ 45 6A      CellTemplate 5?      �� 5@   "   .R�5A   &   �� -   5        $	��❌��5A   -   
���  ��$��15��6J   $��15��6V   $��10(�6a   #��[  6o   6�   5B   #   5D      5F      5G      ]� 5H      $	��500��6   $��30��6$   ���#282828.+�5I      �� $��Right=�6    �� Orientation$ 
Horizontal=�64   $��Right=�6M   $��Center=�6i   .+�5J      �� $��Rabat:��6   
�������$��14(�6@   $��Center=�6N   �� 5K      -   5         ��Name$ txtRabat��5K      $��50��6T   $��0,0,5,0q�6_   $��Center=�6p   
���   �
�������
�������$��1q�6�   $��25��6�   $��14(�6  ��60   �� *DiscountPercentage+6  �� 5L      $��%��6   
�������$��14(�6;   $��Center=�6I   $��0,0,5,0q�6d   5M      5N      ]� 5O      $	��500��6   $��40��6$   ���#282828.+�5P      �� $��Right=�6   $ 
Horizontal=�64   $��Right=�6M   $��Center=�6i   .+�5R      �� $
��Sum:��6   
�������$��18(�6>   $��Center=�6L   �� 5S      -   5        $��lblTotalPris��5S      $��0,0,5,0q�60   
�������$��18(�6T   $��Center=�6c   $��Center=�6�   ��6�   �� *Sum+�� 5T      $��Right=�6   $��0��63   5U      5V      5W      �� 5X   
   $��Button��6   $
��Left=�6"   $��
969,70,0,0q�6=   $	��Top=�6Q   $��0��6i   5Y      5Z      