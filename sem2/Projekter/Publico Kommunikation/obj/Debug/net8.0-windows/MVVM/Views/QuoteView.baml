   M S B A M L   `   `   `  ����X  TPublico_Kommunikation_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullm;clr-namespace:Publico_Kommunikation_Project.MVVM.ViewModels-Publico_Kommunikation_Project.MVVM.ViewModels  5      8    2Publico_Kommunikation_Project.MVVM.Views.QuoteView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Mlocal;clr-namespace:Publico_Kommunikation_Project.MVVM.ViewModels     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � .+�5   
   �� $	��Top=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5           Name$  QuoteDataGrid��5      $��0��5      $
��auto��5      $	��400��5         AutoGenerateColumns$ False��5         CanUserResizeColumns$ False��5         CanUserResizeRows$ False��5         HeadersVisibility$ Column=�5      ��5      �� *QuoteProducts+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 5         Header$ Ydelse��5         
IsReadOnly$
 True��5      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5      �� *ProductName+5        5      $
 0.2* 5      $ Tidsestimat��5!      	 5       �� *QuoteProductTimeEstimate+5!        5"      $
 0.2* 5#      $
 Pris��5%      $
 True��5&      	 5$      �� *QuoteProductPrice+5&      4  .System.Windows.Controls.DataGridTemplateColumn  5'      $
 0.1* 6-   $ Actions��6:   
   CellTemplate
 5(      �� 5)      .R�5*   "   �� $��2q�5+   %   $
��Slet��5.   %   ��5,   %   �� *'%DataContext.DeleteQuoteProductCommand+ �� RelativeSource ��  �� AncestorType UserControl��5-   %   �� 5.   %   5/      51      53      54      �� 55   
   -   5         ��Name$ lblHourlyRate��56      $	��115��57      $��	20,0,0,80q�58      $
��Left=�59      $��Bottom=�5:      .��5;      ��  �� Orientation$ 
Horizontal=�6   .+�5<      �� $��
Timepris: ��6   �� 5=      -   5        $��50��5>      $��20��5?      $��Center=�5@      
�������$��1q�5B       �� TextAlignment$ Center=�5F       �� 
IsReadOnly 5C      �� *HourlyRateIsReadOnly+��5E      �� *
HourlyRate+ �� UpdateSourceTrigger$ PropertyChanged=�5F      5G      5H      �� 5J   
   -   5        $ lblSum��5K      $	��115��5L      $��	20,0,0,40q�5M      $
��Left=�5N      $��Bottom=�5O      .��5P      �� $ 
Horizontal=�6   .+�5Q      �� $��Totalpris: ��6   �� 5R      -   5        $��50��5S      $��20��5T      $��Center=�5U      
�������$��1q�5W      $ Center=�5[       5X      �� *SumIsReadOnly+��5Z      �� *Sum+$ PropertyChanged=�5[      5\      5]      �� 5_   
   -   5        $ lblDiscountPercentage��5`      $	��200��5a      $��
172,0,0,80q�5b      $
��Left=�5c      $��Bottom=�5d      .��5e      �� $ 
Horizontal=�6   .+�5f      �� $��Rabat: ��6   �� 5g      -   5        $��50��5h      $��20��5i      $��Center=�5j      
�������$��1q�5l      $ Center=�5o      ��5n      �� *DiscountPercentage+$ PropertyChanged=�5o      �� 5p      $��%��6   5q      5r      �� 5t   
   -   5        $ lblDiscountedSum��5u      $	��178��5v      $��
172,0,0,54q�5w      $
��Left=�5x      $��Bottom=�5y      .��5z      �� �� 6   $�Pris efter rabat: ��6    �� 5{      �6   �� *DiscountedSum+ �� Mode$ OneWay=�5|      5}      �� 5   
   $	��200��5�      $��40��5�      $��0,0,0,10q�5�      $��Bottom=�5�      ��5�      �� *SwitchCommand+��5�      �� *
SwitchText+5�      5�      