   M S B A M L   `   `   `  ����D  @Tamagochi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Tamagochi	Tamagochi  5   +       Tamagochi.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   &myclr-namespace:Tamagochi     5   +   -   5          � Title$   ��5   	   $	��663��6   $	��902��6    � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterScreen=�6d    � Icon$? 9/Tamagochi;component/Images/сова%20радость.ico��6�   ��5      �� 5   
    �� ImageSource$) #/Tamagochi;component/Images/fon.png��6   .��5      � $	��630��6   $	��635��6   .+�5	   
   � -   5        $��
wrapPanel1��5	   <   $	��101��6   $
��Left=�6!   $	��Top=�6N   $	��435��6f   $��0,-2,0,0q�6r   .+�5
         Tamagochi.Parametr  -   5          Name$ 	HealthBar��5
      $	��100��6-   $	��145��6:     5      -   5        $ 	HungerBar��5      $	��145��6-   $	��100��69     5      -   5        $ MoodBar��5      $	��100��6+   $	��145��68   5      � 5   
   -   5        $��
wrapPanel2��5   O   $	��144��6   $
��Left=�6!   $��	0,480,0,0q�6<   $	��Top=�6a   $	��435��6y   .+�5      �� -   5        $��HealthButton��5   "   $	��140��6   $	��145��66   
���   �$��4q�6V   ��5      �� 5      $6 0/Tamagochi;component/Images/здоровье.png��6!   5      �� 5      -   5        $��button2��5   "   $	��140��6   $	��145��61   
���   �$��4q�6Q   ��5      �� 5      $, &/Tamagochi;component/Images/еда.png��6!   5      �� 5      -	   5        $��
MoodButton��5   "   $	��140��6   $	��145��64   
���   �$��4q�6T   ��5      �� 5      $: 4/Tamagochi;component/Images/настроение.png��6!   5      5      �� 5   
   -
   5        $��label2��5   J   $��73��6   $
��Left=�6   $��	453,0,0,0q�67   $	��Top=�6X   $	��137��6p   $��32(�6|   $
��Bold"�6�   $��Arabic Typesetting)�6�   $��Bottom=�6�   ��5       �� 5!      $= 7/Tamagochi;component/Images/dolar_670_auto_635_auto.png��6   5#      �� 5$   
   -   5        $��
labelMoney��5$   ^   $��Label��6   $��38��6    $��Center=�6,   $��438,63,12,0q�6I   $	��Top=�6p   $	��170��6�   $��Arabic Typesetting)�6�   $��36(�6�   $
��Bold"�6�   $��Right=�6�   �� 5%   
   -   5        $��button1��5%   N   $	��138��6   $
��Left=�6   $��474,480,0,0q�69   $	��Top=�6]   $	��149��6u   $��4q�6�   
���   ���5&      �� 5'      $2 ,/Tamagochi;component/Images/деньги.png��6   5)      � 5*   
   -   5        $��grid1��5*      $��169,178,175,156q�6   67   5+      5,      