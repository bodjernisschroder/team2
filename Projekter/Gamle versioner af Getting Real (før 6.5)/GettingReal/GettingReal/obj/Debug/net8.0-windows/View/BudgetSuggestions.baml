   M S B A M L   `   `   `  ����F  BGettingReal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:GettingReal.ViewGettingReal.View  5   	   (    "GettingReal.View.BudgetSuggestions   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:GettingReal.View     5   	     � Title$  BudgetSuggestions��5   	   $	��450��6#   $	��800��60   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDataGrid��5
         AutoGenerateColumns$ False��6'      SelectionUnit$
 Cell=�6k      HeadersVisibility$ Column=�6�      
IsReadOnly$ False��6�   $��10,98,560,98q�6�   $	��230��6�   ��6C   �� *Budget.Products+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Ydelse��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 65   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6?   �� *Name+  5      $
 Pris��6%   $ 50 63   	 6>   �� *Price+5        5   
   -   5        $ myDataGrid_Copy��5      $ False��6,   $
 Cell=�6p   $ Column=�6�   $ False��6�   $��285,98,285,98q�6�   $	��230��6�   ��6H   �� *Budget.Products+ 5        5      $ Ydelse��6%   $ * 65   	 6?   �� *Name+  5      $
 Pris��6%   $ 50 63   	 6>   �� *Price+5        5    
   -   5        $ myDataGrid_Copy1��5       $ False��6-   $
 Cell=�6q   $ Column=�6�   $ False��6�   $��560,98,10,98q�6�   $	��230��6�   ��6I   �� *Budget.Products+ 5!        5"      $ Ydelse��6%   $ * 65   	 6?   �� *Name+  5#      $
 Pris��6%   $ 50 63   	 6>   �� *Price+5*      �� 5+   
   $%��Budget med lav timepris (1100):��6   $
��Left=�6:   $��30��6U   $��	10,63,0,0q�6a   $	��Top=�6t   $	��230��6�   $��SemiBold"�6�   �� 5,   
   $&�� Budget med høj timepris (1600):��6   $
��Left=�6:   $��30��6U   $��
560,63,0,0q�6a   $	��Top=�6u   $	��230��6�   $��SemiBold"�6�   �� 5-   
   $,��&Budget med mellemhøj timepris (1300):��6   $��Center=�6@   $��30��6]   $��0,63,0,0q�6i   $	��Top=�6{   $	��230��6�   $��SemiBold"�6�   5.      5/      