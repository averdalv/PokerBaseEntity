   M S B A M L   `   `   `  ����J  FPokerBaseEntity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PokerBaseEntity.ViewModelPokerBaseEntity.ViewModel  5   	        PokerBaseEntity.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9local'clr-namespace:PokerBaseEntity.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � DataContext 5      3  -PokerBaseEntity.ViewModel.ViewModelMainWindow  5   
    � 	Resources 5	       �� 
StartPoint �� EndPoint 	  brush � Offset � Color �� 
TargetType  
baseButton �� Property	 �� Value
 �� BasedOn  withBackground��%�  &	        &	 �     &	 p    7  7   �� 5
   
   $	 0,0&�6   $	 1,1&�6/   .��5      � $ 0Q�6   $ Black��6&   66   � 5      $	 0.5Q�6   $ DarkSlateBlue��6(   6@   � 5      $ 1Q�6   $ Black��6&   66   5      �� 5   
   " ��6   .�5      ��  � ��$	 10q�6'   �� 5       � ��$		 165��6&   64   �� 5       � ��$	 40��6'   64   5      �� 5   
   " ��6   8
   .�5      ��  � ��8	  6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��10q�6   $	��165��6   $��40��6)   $��Get Players��65   ��6L   �� *OpenGetRequest+6q   �� 5    
   $��1��6   $��10q�6   $	��165��6+   $��40��67   $��Get Tournaments��6C   ��6]   �� *OpenGetTournaments+6�   5!      5"      