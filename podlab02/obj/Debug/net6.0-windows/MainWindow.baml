   M S B A M L   `   `   `  ����C  ?podlab02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:podlab02podlab02  5   	       podlab02.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:podlab02     5   	     � Title$  Матрицы��5   	   $	��600��6   $
��1000��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��450 �6   �� 5      $	��100 �6   �� 5      $	��450 �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��500 �6   �� 5      $��50 �6   .+�5   
   �� $��0��6   $��0��6!   $+��%Введите размерность��61   $��16(�6L   $��10, 10, 280, 10q�6Z   �� 5   
   -   5        $��EnterDimensions��5   F   $��0��6   $��0��6   $��190,15,245,20q�6/   6F   �� 5   
   -   5        $��Create��5   W   $��0��6   $��0��6   $��220,10,150,15q�6.   $��Создать��6E   6W   �� 5   
   -   5        $��Choice��5   E   $��2��6   $��2��6    $��10,5,300,20q�60   .@�5      �� $��Сложение��6   �� 5      $��Умножение��6   5      �� 5   
   -   5        $��Result��5   Y   $��2��6   $��2��6   $��Рассчитать��6.   $��170,5,160,20q�6C   6Y   �� 5   
   -   5        $
��Save��5   W   $��2��6   $��2��6   $��Сохранить��6.   $��310,5,10,20q�6B   6W   &   System.Windows.Controls.DataGrid  5   
   -   5        $��GridLeft��5   ?   $��1��6   $��0��6    $��30,55q�60      AutoGenerateColumns$ False��6O      
IsReadOnly$ False��6k     5   
   -   5        $��	GridRight��5   ?   $��1��6   $��2��6    $��30,55q�60   $ False��6P   $ False��6l   5"      5#      