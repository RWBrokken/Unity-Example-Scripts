/ *     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
       	     S a v e   U t i l i t y   S c r i p t 	 	 V . 2 . 3 	 	 O r i g i n a l l y   c o d e d   b y :   R i c h a r d   B r o k k e n     1 2 / 2 0 1 7  
       	     U s e :   M a n a g e d   s a v e   a n d   l o a d   s y s t e m 	 	 C u s t o m i z e d   b y :    
       	     D e s c r i p t i o n :   T h i s   i s   a n   e x a m p l e   f o r   a   f i l e s a v e   c o n t r o l l e r   o b j e c t ,   w i t h   p o t e n t i a l  
       	                     f o r   m u l t i p l e   s a v e s   ( i e .   d i f f e r e n t   l e v e l s )   b a s e d   o n   f i l e n a m e s ,   i n   a d d i t i o n  
 	 	 	     t o   a   h i g h s c o r e   l i s t   w i t h   a s c e n d i n g   a n d   d e s c e n d i n g   s o r t   f u n c t i o n .  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -     * /  
  
  
 u s i n g   S y s t e m . C o l l e c t i o n s ;  
 u s i n g   S y s t e m . C o l l e c t i o n s . G e n e r i c ;  
 u s i n g   U n i t y E n g i n e ;  
 / /         T h e   f o l l o w i n g   a r e   u s e d   t o   a c c e s s   o t h e r   n e s s e s s a r y   n a m s p a c e s   f o r   f i l e   o p e r a t i o n s  
 u s i n g   S y s t e m ;  
 u s i n g   S y s t e m . R u n t i m e . S e r i a l i z a t i o n . F o r m a t t e r s . B i n a r y ;  
 u s i n g   S y s t e m . I O ;  
  
 / /         C o m m e n t e d   o u t   a s   t h i s   e x a m p l e   h a s   t h e   s e t t i n g s   o n   t h e   G a m e C o n t r o l l e r   o b j e c t ,   p r o v i d e d   h e r e   f o r   i n f o r m a t i o n  
 / / [ S y s t e m . S e r i a l i z a b l e ]  
 / / p u b l i c   c l a s s   A p p S e t t i n g s   {  
 / / 	 p u b l i c   s t r i n g   t e s t S t r i n g ;  
 / / 	 p u b l i c   s t r i n g   l o a d T e s t ;  
 / /  
 / / 	 [ H e a d e r ( " S a v e   f i l e n a m e s " ) ]  
 / / 	 p u b l i c   s t r i n g   s e t t i n g s S a v e ;  
 / / 	 p u b l i c   s t r i n g   g a m e S a v e ;  
 / / 	 p u b l i c   s t r i n g   p l a y e r S a v e ;  
 / / 	 p u b l i c   s t r i n g   h i g h s c o r e S a v e ;  
 / / 	 / /   E x t r a s   f o r   H i g h S c o r e  
 / / 	 p u b l i c   b o o l   _ I _ _ _ E r a s e F i l e ;  
 / / }  
 / /         P r i m a r y   e x e c u t i o n   s c r i p t ,   o n l y   n e e d s   d e c l a r a t i o n s .   C a n   h a v e   f u n c t i o n s .  
 p u b l i c   c l a s s   F i l e C o n t r o l l e r   :   M o n o B e h a v i o u r   {  
 	 p u b l i c   b o o l   d e b u g M s g s E n a b l e d   =   t r u e ;  
 	 [ H i d e I n I n s p e c t o r ]     / /         U s e d   t o   h i d e   t h i s   a p p s e t t i n g s   i n s t a n c e   a n d   v a l u e s   t h e r e i n   f r o m   t h e   I n s p e c t o r   v i e w   a s   p u l l   f r o m   c l a s s   o n   a n o t h e r   o b j e c t   -   g a m e c o n t r o l l e r  
 	 p u b l i c   A p p S e t t i n g s   a p p S e t t i n g s ;  
 	 p u b l i c   G a m e F i l e   g a m e F i l e ;  
 	 p u b l i c   H i g h S c o r e _ C   h i g h S c o r e ;  
 	 v o i d   S t a r t ( )   {  
 	 	 D o n t D e s t r o y O n L o a d ( t h i s ) ;  
 	 	 a p p S e t t i n g s   =   G a m e O b j e c t . F i n d O b j e c t O f T y p e < G a m e C o n t r o l l e r >   ( ) . a p p S e t t i n g s ;  
 	 	 / /     !     T h i s   c h e c k   p o r t i o n   i s   n e s s e s s a r y   t o   s u c c e s s f u l l y   c r e a t e   n e w   f i l e s / d i r e c t o r i e s  
 	 	 g a m e F i l e . f i l e C h e c k ( ) ;  
 	 	 h i g h S c o r e . f i l e C h e c k ( ) ;  
 	 	 i f   ( d e b u g M s g s E n a b l e d )   D e b u g . L o g   ( " g a m e   d a t a   @   " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " ) ;  
 	 }  
 	 v o i d   F i x e d U p d a t e ( )   {  
 	 	 / /         I n   c a s e   t h e   o r i g i n a l l y   r e f e r r a n c e d   o b j e c t   f o r   A p p S e t t i n g s   g o e s   m i s s i n g ,   s u c h   a s   a   l e v e l   l o a d  
 	 	 i f   ( a p p S e t t i n g s   = =   n u l l )   a p p S e t t i n g s   =   G a m e O b j e c t . F i n d O b j e c t O f T y p e < G a m e C o n t r o l l e r >   ( ) . a p p S e t t i n g s ;  
 	 	 i f   ( a p p S e t t i n g s . _ I _ _ _ E r a s e F i l e )   {  
 	 	 	 a p p S e t t i n g s . _ I _ _ _ E r a s e F i l e   =   f a l s e ;  
 	 	 	 D e b u g . L o g E r r o r ( " E r a s i n g :   " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h   +   " \ \ "   +   a p p S e t t i n g s . h i g h s c o r e S a v e ) ;  
 	 	 	 F i l e . D e l e t e ( A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h   +   " \ \ "   +   a p p S e t t i n g s . h i g h s c o r e S a v e ) ;  
 	 	 }  
 	 }  
 	 v o i d   O n A p p l i c a t i o n E x i t ( )   {  
 	 	 i f   ( d e b u g M s g s E n a b l e d )   D e b u g . L o g   ( " A p p   E x i t " ) ;  
 	 }  
 	 v o i d   O n A p p l i c a t i o n Q u i t ( )   {  
 	 	 i f   ( d e b u g M s g s E n a b l e d )   D e b u g . L o g   ( " A p p   Q u i t " ) ;  
 	 }  
 	 / /     E x t r a   f u n c t i o n s   ( i n - p r o g r e s s )  
 	 p u b l i c   c l a s s   E x t r a _ U t i l i t i e s   {  
 	 	 / / 	 	 I n - P r o g r e s s :  
 	 	 / / 	 	 p u b l i c   f l o a t   C o n v e r t F r o m S c i e n t i f i c N o t a t i o n   ( f l o a t   v a l u e T o C o n v e r t )   {  
 	 	 / / 	 	 	 / /         U s e :   T o   c o n v e r t   v a l u e s   w h i c h   b e c o m e   s c i e n t i f i c a l l y   n o t a t e d  
 	 	 / / 	 	 }  
 	 	 p u b l i c   i n t   f u n c _ C o n v e r t F l o a t T o I n t   ( f l o a t   f l o a t V a l ,   b o o l   r o u n d D o w n   =   t r u e )   {  
 	 	 	 i f   ( r o u n d D o w n )  
 	 	 	 	 r e t u r n   ( M a t h f . F l o o r T o I n t   ( f l o a t V a l ) ) ;  
 	 	 	 e l s e  
 	 	 	 	 r e t u r n   ( M a t h f . C e i l T o I n t   ( f l o a t V a l ) ) ;  
 	 	 }  
  
 	 	 p r i v a t e   c h a r [ ]   P r o c e s s S t r i n g ( s t r i n g   i n S t r i n g )   {  
 	 	 	 c h a r [ ]   c _ a r r a y ;  
 	 	 	 c _ a r r a y   =   i n S t r i n g . T o C h a r A r r a y   ( ) ;  
 	 	 	 r e t u r n   c _ a r r a y ;  
 	 	 }  
 	 	 p r i v a t e   s t r i n g   P r o c e s s C h a r A r r a y ( c h a r [ ]   i n C h a r A r r a y ) {  
 	 	 	 s t r i n g   o u t S t r i n g   =   " " ;  
 	 	 	 c h a r   e v a l C h a r ;  
 	 	 	 f o r   (   i n t   i = 0 ;   i   <   i n C h a r A r r a y . L e n g t h ;   i + +   )   {  
 	 	 	 	 e v a l C h a r   =   i n C h a r A r r a y   [ i ] ;  
 	 	 	 	 o u t S t r i n g   + =   e v a l C h a r . T o S t r i n g   ( ) ;  
 	 	 	 }  
 	 	 	 r e t u r n   o u t S t r i n g ;  
 	 	 }  
 	 }  
 }  
 [ S y s t e m . S e r i a l i z a b l e ]  
 p u b l i c   c l a s s   G a m e F i l e   {  
 	 p r i v a t e   F i l e C o n t r o l l e r   _ C o n t r o l l e r   {   g e t   {   r e t u r n   G a m e O b j e c t . F i n d O b j e c t O f T y p e < F i l e C o n t r o l l e r >   ( ) ;   }   }  
 	 p r i v a t e   A p p S e t t i n g s   a p p S e t t i n g s   {   g e t   {   r e t u r n   _ C o n t r o l l e r . a p p S e t t i n g s ;   }   }  
 	 p u b l i c   b o o l   i s L o a d i n g ,   i s S a v i n g ;  
 	 / /         T h i s   c h e c k   p o r t i o n   i s   n e s s e s s a r y   t o   s u c c e s s f u l l y   c r e a t e   n e w   f i l e s / d i r e c t o r i e s  
 	 p u b l i c   v o i d   f i l e C h e c k   ( )   {  
 	 	 / /         C h e c k   f o r   t h e   s a v e   f i l e s  
 	 	 i f   ( F i l e . E x i s t s ( " " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + a p p S e t t i n g s . p l a y e r S a v e )  
 	 	 	 & &  
 	 	 	 F i l e . E x i s t s   ( " " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + a p p S e t t i n g s . g a m e S a v e ) )   {  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r   ( " S a v e   f i l e s   f o u n d . " ) ;  
 	 	 	 r e t u r n ;  
 	 	 }  
 	 	 / /         I f   n o   s a v e   f i l e s   f o u n d   t h e n   c r e a t e   n e w  
 	 	 i f   ( ! F i l e . E x i s t s ( " " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + a p p S e t t i n g s . g a m e S a v e ) )   {  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r   ( "     N o   \ ' g a m e \ '   s a v e   f o u n d ! \ t . . c r e a t i n g . \ n " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + a p p S e t t i n g s . g a m e S a v e ) ;  
 	 	 	 S a v e   ( " n e w G a m e " ) ;  
 	 	 }  
 	 	 i f   ( ! F i l e . E x i s t s ( " " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + a p p S e t t i n g s . p l a y e r S a v e ) )   {  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r   ( "     N o   \ ' p l a y e r \ '   s a v e   f o u n d ! \ t . . c r e a t i n g . \ n " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + a p p S e t t i n g s . p l a y e r S a v e ) ;  
 	 	 	 S a v e   ( " n e w P l a y e r " ) ;  
 	 	 }  
 	 }  
 	 p u b l i c   v o i d   S a v e ( s t r i n g   i n S a v e C m d )   {  
 	 	 i s S a v i n g   =   t r u e ;  
 	 	 i f   ( i n S a v e C m d   = =   " g a m e "   | |   i n S a v e C m d   = =   " n e w G a m e "   | |    
 	 	 	 i n S a v e C m d   = =   " p l a y e r "   | |   i n S a v e C m d   = =   " n e w P l a y e r " )   {  
 	 	 	 s t r i n g   s a v e P a t h   =   " n e w F i l e " ;  
 	 	 	 i f   ( i n S a v e C m d   = =   " g a m e "   | |   i n S a v e C m d   = =   " n e w G a m e " )   {  
 	 	 	 	 s a v e P a t h   =   a p p S e t t i n g s . g a m e S a v e ;  
 	 	 	 }  
 	 	 	 e l s e   i f   ( i n S a v e C m d   = =   " p l a y e r "   | |   i n S a v e C m d   = =   " n e w P l a y e r " )   {  
 	 	 	 	 s a v e P a t h   =   a p p S e t t i n g s . p l a y e r S a v e ;  
 	 	 	 }  
 	 	 	 B i n a r y F o r m a t t e r   b f   =   n e w   B i n a r y F o r m a t t e r   ( ) ;  
 	 	 	 F i l e S t r e a m   f i l e   =   F i l e . O p e n   ( ( " "   +   A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h   +   " \ \ "   +   s a v e P a t h   +   " " ) ,   F i l e M o d e . O p e n O r C r e a t e ,   F i l e A c c e s s . R e a d W r i t e ) ;  
 	 	 	 G a m e S a v e S t r u c t   d a t a G S   =   n e w   G a m e S a v e S t r u c t   ( ) ;  
 	 	 	 / / 	 	 	 i f   ( i n S a v e C m d   = =   " n e w G a m e "   | |   i n S a v e C m d   = =   " n e w P l a y e r " )   {  
 	 	 	 / / 	 	 	 / /         C r e a t e   b a s i c   s a v e   u n d e r   t h e   G a m e S a v e S t r u c t   f o r   b o t h   f i l e s   a s   t h i s   s c r i p t   c u r r e n t l y   s t a n d s  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t S c o r e   =   0 ;  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t L v L   =   1 ;  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t H P   =   3 ;  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t S P   =   0 f ;  
 	 	 	 / / 	 	 	 	 d a t a G S . s t r i n g T e x t   =   " h e l l o " ;  
 	 	 	 / / 	 	 	 }   e l s e   {  
 	 	 	 / / 	 	 	 / /         S a v e   t h e   v a l u e s   f r o m   t h e   c u r r e n t   r u n n i n g   g a m e   t o   t h e   G a m e S a v e S t r u c t   f o r   b o t h   t h e   g a m e   a n d   p l a y e r   a s   s c r i p t   c u r r e n t l y   s t a n d s  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t S c o r e   =   g a m e C t r l r . s c o r e ;  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t L v L   =   g a m e C t r l r . a p p S e t t i n g s . h a z a r d C o u n t - 2 ;  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t H P   =   g a m e C t r l r . p l a y e r c o n t r o l l e r . p l a y e r H e a l t h . H e a l t h ( ) ;  
 	 	 	 / / 	 	 	 	 d a t a G S . c u r r e n t S P   =   g a m e C t r l r . p l a y e r c o n t r o l l e r . p l a y e r S h e i l d S c r i p t . S h e i l d H e a l t h ( ) ;  
 	 	 	 / / 	 	 	 }  
 	 	 	 b f . S e r i a l i z e   ( f i l e ,   d a t a G S ) ;  
 	 	 	 f i l e . C l o s e   ( ) ;  
 	 	 }  
 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g W a r n i n g   ( " " + i n S a v e C m d + "   s a v e d " ) ;  
 	 	 i s S a v i n g   =   f a l s e ;  
 	 }      
 	 p u b l i c   v o i d   L o a d ( s t r i n g   i n L o a d C m d )   {  
 	 	 i s L o a d i n g   =   t r u e ;  
 	 	 i f   ( i n L o a d C m d   = =   " g a m e "   | |   i n L o a d C m d   = =   " p l a y e r " )   {  
  
 	 	 	 i f   ( i n L o a d C m d   = =   " g a m e " )   {  
 	 	 	 	 i n L o a d C m d   =   a p p S e t t i n g s . g a m e S a v e ;  
 	 	 	 }  
 	 	 	 i f   ( i n L o a d C m d   = =   " p l a y e r " )   {  
 	 	 	 	 i n L o a d C m d   =   a p p S e t t i n g s . p l a y e r S a v e ;  
 	 	 	 }  
 	 	 	 B i n a r y F o r m a t t e r   b f   =   n e w   B i n a r y F o r m a t t e r   ( ) ;  
 	 	 	 F i l e S t r e a m   f i l e   =   F i l e . O p e n   ( ( " "   +   A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h   +   " \ \ "   +   i n L o a d C m d   +   " " ) ,   F i l e M o d e . O p e n O r C r e a t e ,   F i l e A c c e s s . R e a d W r i t e ,   F i l e S h a r e . I n h e r i t a b l e ) ;  
 	 	 	 # p r a g m a   w a r n i n g   d i s a b l e   0 2 1 9     / /       U s e d   t o   q u i t   i t s   c o m p l a i n i n g   a s   e m p t y   i n   t h i s   e x a m p l e ,   t e m p  
 	 	 	 G a m e S a v e S t r u c t   d a t a G S   =   ( G a m e S a v e S t r u c t ) b f . D e s e r i a l i z e   ( f i l e ) ;  
 	 	 	 # p r a g m a   w a r n i n g   r e s t o r e   0 2 1 9  
 	 	 	 f i l e . C l o s e   ( ) ;  
 	 	 	 / /         R e s t o r e   v a l u e s   f r o m   t h e   s a v e   f i l e   t o   t h e   g a m e ,   a n   e x a m p l e   u s e  
 	 	 	 / / 	 	 	 g a m e C t r l r . s c o r e   =   d a t a G S . c u r r e n t S c o r e ;  
 	 	 	 / / 	 	 	 g a m e C t r l r . B r o a d c a s t M e s s a g e   ( " U p d a t e S c o r e " ) ;  
 	 	 	 / / 	 	 	 g a m e C t r l r . l e v e l S e l e c t o r   ( d a t a G S . c u r r e n t L v L ) ;  
 	 	 	 / / 	 	 	 i f   ( g a m e C t r l r . p l a y e r c o n t r o l l e r ! = n u l l ) {  
 	 	 	 / / 	 	 	 	 g a m e C t r l r . p l a y e r c o n t r o l l e r . p l a y e r H e a l t h . S e t H e a l t h ( d a t a G S . c u r r e n t H P ) ;  
 	 	 	 / / 	 	 	 	 g a m e C t r l r . p l a y e r c o n t r o l l e r . p l a y e r S h e i l d S c r i p t . S e t S h e i l d S t r e n g t h ( d a t a G S . c u r r e n t S P ) ;  
 	 	 	 / / 	 	 	 _ C o n t r o l l e r . a p p S e t t i n g s . t e s t S t r i n g   =   d a t a G S . s t r i n g T e x t ;    
 	 	 	 / / 	 	 	 _ C o n t r o l l e r . a p p S e t t i n g s . l o a d T e s t   =   d a t a G S . c u r r e n t S c o r e . T o S t r i n g   ( ) ;  
 	 	 }  
 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g W a r n i n g   ( " "   +   i n L o a d C m d   +   "   l o a d e d " ) ;  
 	 	 i s L o a d i n g   =   f a l s e ;  
 	 }  
 }  
 [ S y s t e m . S e r i a l i z a b l e ]  
 p u b l i c   c l a s s   H i g h S c o r e _ C   {  
 	 p r i v a t e   F i l e C o n t r o l l e r   _ C o n t r o l l e r   {   g e t   {   r e t u r n   G a m e O b j e c t . F i n d O b j e c t O f T y p e < F i l e C o n t r o l l e r >   ( ) ;   }   }  
 	 p r i v a t e   A p p S e t t i n g s   a p p S e t t i n g s   {   g e t   {   r e t u r n   _ C o n t r o l l e r . a p p S e t t i n g s ;   }   }  
 	 p r i v a t e   s t r i n g   _ f i l e L o c a t i o n   {   g e t   {   r e t u r n   a p p S e t t i n g s . h i g h s c o r e S a v e ;   }   }  
 	 p u b l i c   b o o l   i s L o a d i n g ,   i s S a v i n g ;  
 	 [ H e a d e r ( " S c o r e   L i s t   S t u f f " ) ]  
 	 p u b l i c   i n t   n u m b e r O f E n t r i e s   =   1 0 ;  
 	 p u b l i c   b o o l   n e w H i g h S c o r e ;  
 	 p u b l i c   L i s t   < H i g h s c o r e >   H i g h s c o r e s   =   n e w   L i s t < H i g h s c o r e > ( ) ;  
 	 / /         T h i s   c h e c k   p o r t i o n   a p p e a r s   t o   b e   n e s s e s s a r y   t o   s u c c e s s f u l l y   c r e a t e   n e w   f i l e s / d i r e c t o r i e s  
 	 p u b l i c   v o i d   f i l e C h e c k   ( s t r i n g   F i l e N a m e   =   " " ,   b o o l   i s D e s c e n d i n g   =   t r u e )   {  
 	 	 i f   ( F i l e N a m e   = =   " " )   / * t h e n * /   F i l e N a m e   =   _ f i l e L o c a t i o n ;  
 	 	 / /         C h e c k   f o r   t h e   s a v e   f i l e s  
 	 	 i f   ( F i l e . E x i s t s ( " " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + F i l e N a m e ) )   {  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r   ( "     H i g h s c o r e   \ ' "   +   F i l e N a m e   +   " \ '   f i l e   f o u n d . " ) ;  
 	 	 	 r e t u r n ;  
 	 	 }  
 	 	 / /         I f   n o   s a v e   f i l e s   f o u n d   t h e n   c r e a t e   n e w  
 	 	 i f   ( ! F i l e . E x i s t s ( " " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + F i l e N a m e ) )   {  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r   ( "     N o   \ ' "   +   F i l e N a m e   +   " \ '   f i l e   f o u n d ! \ t . . c r e a t i n g . \ n L o c a t i o n : " + A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h + " \ \ " + F i l e N a m e ) ;  
 	 	 	 i f   ( i s D e s c e n d i n g )   {  
 	 	 	 	 S a v e   ( F i l e N a m e ,   i s D e s c e n d i n g ,   " n e w f i l e " ) ;  
 	 	 	 }   e l s e   {  
 	 	 	 	 S a v e   ( F i l e N a m e ,   i s D e s c e n d i n g ,   " - n e w f i l e " ) ;  
 	 	 	 }  
 	 	 }  
 	 }  
 	 p u b l i c   v o i d   S a v e   ( s t r i n g   S a v e F i l e N a m e   =   " " ,   b o o l   i s D e s c e n d i n g   =   t r u e ,   s t r i n g   i n O p t i o n s   =   " " )   {  
 	 	 i s S a v i n g   =   t r u e ;  
 	 	 i f   ( S a v e F i l e N a m e   = =   " " )   {    
 	 	 	 S a v e F i l e N a m e   =   _ f i l e L o c a t i o n ; 	 	 	  
 	 	 }   e l s e   {  
 	 	 	 / /     I n f a n i t e   l o o p / b r e a k   w i t h o u t   w a r n i n g ,   j u s t   r u n   a   f i l e c h e c k ( )   b e f o r e   f i r s t   o r   e a c h   s a v e  
 	 	 	 / / 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g W a r n i n g   ( " S a v e   r e c e i v e d   f i l e n a m e   t o   u s e :   "   +   S a v e F i l e N a m e ) ;  
 	 	 	 / / 	 	 	 i f   ( S a v e F i l e N a m e   ! =   _ f i l e L o c a t i o n   & &   ( i n O p t i o n s   ! =   " n e w f i l e "   | |   i n O p t i o n s   ! =   " - n e w f i l e " ) )   {  
 	 	 	 / / 	 	 	 	 f i l e C h e c k   ( S a v e F i l e N a m e ,   i s D e s c e n d i n g ) ;  
 	 	 	 / / 	 	 	 }  
 	 	 }  
 	 	 B i n a r y F o r m a t t e r   b f   =   n e w   B i n a r y F o r m a t t e r   ( ) ;  
 	 	 F i l e S t r e a m   f i l e   =   F i l e . O p e n   ( ( " "   +   A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h   +   " \ \ "   +   S a v e F i l e N a m e ) ,   F i l e M o d e . O p e n O r C r e a t e ,   F i l e A c c e s s . R e a d W r i t e ) ;  
 	 	 H i g h S c o r e _ C   d a t a H S   =   n e w   H i g h S c o r e _ C   ( ) ;  
 	 	 i f   ( i n O p t i o n s   = =   " n e w f i l e " )   {  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r ( " S e t t i n g   d e s c e n d i n g   s k e l e t o n   v a l u e s " ) ;  
 	 	 	 H i g h s c o r e s . C l e a r   ( ) ;     / /         E n s u r e s   t h e   l i s t   i s   c l e a r   w h e n   m a k i n g   a   n e w   f i l e  
 	 	 	 / /   M a k e   s o m e t h i n g   t o   s h o w ,   o r   n o t . .  
 	 	 	 S u b m i t S c o r e ( 4 2 ,   " E v e r y t h i n g " ) ;  
 	 	 	 S u b m i t S c o r e ( 1 0 0 0 0 0 0 ,   " D r .   E v i l " ) ;  
 	 	 	 S u b m i t S c o r e ( 1 2 3 4 5 6 7 8 9 0 ,   " 7 # 3 C r 3 4 7 0 r - 1 3 3 7 " ) ;  
 	 	 	 S u b m i t S c o r e ( 1 0 0 0 0 0 0 0 0 0 ,   " D r .   E v i l   ( r e v i s e d ) " ) ;  
 	 	 	 S u b m i t S c o r e   ( 6 6 6 ,   " R E D R U M " ) ;  
 	 	 	 n e w H i g h S c o r e   =   f a l s e ;  
 	 	 }  
 	 	 i f   ( i n O p t i o n s   = =   " - n e w f i l e " )   {  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r ( " S e t t i n g s   a s c e n d i n g   s k e l e t o n   v a l u e s " ) ;  
 	 	 	 H i g h s c o r e s . C l e a r   ( ) ;     / /         E n s u r e s   t h e   l i s t   i s   c l e a r   w h e n   m a k i n g   a   n e w   f i l e  
 	 	 	 / /   M a k e   s o m e t h i n g   t o   s h o w ,   o r   n o t . .  
 	 	 	 S u b m i t S c o r e ( - 4 2 ,   " N o t h i n g " ) ;  
 	 	 	 S u b m i t S c o r e ( - 1 0 0 0 0 0 0 ,   " U N   t o   p a y   D r .   E v i l " ) ;  
 	 	 	 S u b m i t S c o r e ( - 1 2 3 4 5 6 7 8 9 0 ,   " i n s _ y o u r - n a m e - h e r e " ) ;  
 	 	 	 S u b m i t S c o r e ( - 1 0 0 0 0 0 0 0 0 0 ,   " A   M i l   i s n t   t h a t   m u c h " ) ;  
 	 	 	 S u b m i t S c o r e   ( - 6 6 6 ,   " M U R D E R " ) ;  
 	 	 	 n e w H i g h S c o r e   =   f a l s e ;  
 	 	 }  
 	 	 H i g h s c o r e s . S o r t ( ) ;  
 	 	 i f   ( i s D e s c e n d i n g   = =   f a l s e ) 	 H i g h s c o r e s . R e v e r s e   ( ) ;  
 	 	 d a t a H S . H i g h s c o r e s   =   H i g h s c o r e s ;  
 	 	 b f . S e r i a l i z e   ( f i l e ,   d a t a H S ) ;  
 	 	 f i l e . C l o s e   ( ) ;  
 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g W a r n i n g   ( " H i g h s c o r e s   s a v e d   t o   "   +   S a v e F i l e N a m e ) ;  
 	 	 i s S a v i n g   =   f a l s e ;  
 	 }      
 	 p u b l i c   v o i d   L o a d   ( s t r i n g   L o a d F i l e N a m e   =   " " )   {  
 	 	 i s L o a d i n g   =   t r u e ;  
 	 	 i f   ( L o a d F i l e N a m e   = =   " " )   {    
 	 	 	 L o a d F i l e N a m e   =   _ f i l e L o c a t i o n ; 	 	 	  
 	 	 }  
 	 	 B i n a r y F o r m a t t e r   b f   =   n e w   B i n a r y F o r m a t t e r   ( ) ;  
 	 	 F i l e S t r e a m   f i l e   =   F i l e . O p e n   ( ( " "   +   A p p l i c a t i o n . p e r s i s t e n t D a t a P a t h   +   " \ \ "   +   L o a d F i l e N a m e ) ,   F i l e M o d e . O p e n O r C r e a t e ,   F i l e A c c e s s . R e a d W r i t e ) ;  
 	 	 H i g h S c o r e _ C   d a t a H S   =   ( H i g h S c o r e _ C ) b f . D e s e r i a l i z e   ( f i l e ) ;  
 	 	 f i l e . C l o s e   ( ) ;  
 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g E r r o r   ( " R e s t o r i n g   s c o r e   v a l u e s   f r o m   s a v e ,   f i l e :   "   +   d a t a H S . H i g h s c o r e s . C o u n t   +   " \ t e n v   b e f o r e :   "   +   H i g h s c o r e s . C o u n t ) ;  
 	 	 H i g h s c o r e s . C l e a r   ( ) ;    
 	 	 n e w H i g h S c o r e   =   f a l s e ;  
 	 	 H i g h s c o r e s   =   d a t a H S . H i g h s c o r e s ;  
 	 	 C h e c k N u m E n t r i e s   ( ) ;  
 	 	 / / n e w H i g h S c o r e   =   f a l s e ;   / /         E n s u r e   t h a t   t h i s   w a s   n o t   s a v e d   o r   t h a t   i t   r e s e t s   o n   n e x t   l o a d ,   n e s s e s s a r y   i f   e n t i r e   c l a s s   i s   s e r i a l i z e d   n o t   j u s t   t h a t   o f   t h e   s t r u c t  
 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g W a r n i n g   ( " "   +   L o a d F i l e N a m e   +   "   l o a d e d " ) ;  
 	 	 i s L o a d i n g   =   f a l s e ;  
 	 }  
 	 p u b l i c   v o i d   S u b m i t S c o r e   ( / * f l o a t * /   d o u b l e   S c o r e ,   s t r i n g   N a m e ,   b o o l   d e s c   =   t r u e ) {  
 	 	 H i g h s c o r e   _ s u b m i t t i n g   =   n e w   H i g h s c o r e   ( S c o r e ,   N a m e ) ;  
 	 	 H i g h s c o r e s . A d d   ( _ s u b m i t t i n g ) ;  
 	 	 H i g h s c o r e s . S o r t   ( ) ;  
  
 	 	 i f   ( ! d e s c )   H i g h s c o r e s . R e v e r s e ( ) ;  
 	 	 C h e c k N u m E n t r i e s   ( ) ;  
 	 	 i f   ( H i g h s c o r e s . C o n t a i n s   ( _ s u b m i t t i n g ) )   {  
 	 	 	 n e w H i g h S c o r e   =   t r u e ;  
 	 	 	 i f   ( _ C o n t r o l l e r . d e b u g M s g s E n a b l e d )   D e b u g . L o g W a r n i n g   ( " \ t N e w   H i g h   S c o r e   ! ! ! " ) ;  
 	 	 }   e l s e   n e w H i g h S c o r e   =   f a l s e ;  
 	 }  
 	 p r i v a t e   v o i d   C h e c k N u m E n t r i e s   ( )   {  
 	 	 i f   ( H i g h s c o r e s . C o u n t   >   n u m b e r O f E n t r i e s )   {  
 	 	 	 f o r   ( i n t   i   =   n u m b e r O f E n t r i e s ;   H i g h s c o r e s . C o u n t   > =   i ;   i + + )   {  
 	 	 	 	 H i g h s c o r e s . R e m o v e A t ( i ) ; 	  
 	 	 	 }  
 	 	 }  
 	 }  
 }  
 # r e g i o n   S a v e   S t r u c t s  
 [ S y s t e m . S e r i a l i z a b l e ]  
 p u b l i c   c l a s s   H i g h s c o r e   :   I C o m p a r a b l e < H i g h s c o r e >   {  
 	 / /         M a d e   t h e   c l a s s   p u b l i c   h e r e   a s   t h e   p u b l i c   l i s t   c o m p l a i n s   w i t h o u t ,   e a s i e r   t o   a c c e s s   l i s t   t h a n   u s e   f u n c t i o n   t o   r e t u r n   v a l e s  
 	 p u b l i c   / * f l o a t * /   d o u b l e   S c o r e ;  
 	 p u b l i c   s t r i n g   N a m e ;  
 	 p u b l i c   H i g h s c o r e   ( / * f l o a t * /   d o u b l e   _ S c o r e ,   s t r i n g   _ N a m e )   {  
 	 	 S c o r e   =   _ S c o r e ;  
 	 	 N a m e   =   _ N a m e ;  
 	 }  
 	 p u b l i c   i n t   C o m p a r e T o   ( H i g h s c o r e   o t h e r )   {  
 	 	 i f   ( o t h e r   = =   n u l l )   {   r e t u r n   1 ;   }  
 	 	 i f   ( S c o r e   >   o t h e r . S c o r e )   {   r e t u r n   - 1 ;   }  
 	 	 i f   ( S c o r e   <   o t h e r . S c o r e )   {   r e t u r n   1 ;   }    
 	 	 e l s e   {   r e t u r n   0 ;   }  
 	 }  
 }  
  
 / /         M u s t   h a v e   t h e   v a l u e s   s h o w i n g   a s   p u b l i c   s o   t h a t   t h e   o t h e r   f u n c t i o n s   w i l l   b e   a b l e   t o   s e e   a n d   l o c a t e   t h e   i n f o r m a i t o n .  
 [ S y s t e m . S e r i a l i z a b l e ]  
 c l a s s   G a m e S a v e S t r u c t   {  
 	 / / 	 p u b l i c   i n t   c u r r e n t S c o r e ;  
 	 / / 	 p u b l i c   i n t   c u r r e n t L v L ;  
 	 / / 	 p u b l i c   i n t   c u r r e n t H P ;  
 	 / / 	 p u b l i c   f l o a t   c u r r e n t S P ;  
 	 / / 	 p u b l i c   s t r i n g   s t r i n g T e x t ;  
 }  
 / / [ S y s t e m . S e r i a l i z a b l e ]  
 / / c l a s s   G a m e S e t t i n g s   {  
 / / 	 V e c t o r 2   S c r e e n R e s o l u t i o n ;  
 / / 	 b o o l   F u l l S c r e e n E n a b l e ;  
 / / }  
 # e n d r e g i o n  
 