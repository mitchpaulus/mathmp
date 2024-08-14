grammar Mathmp ;

file : (math '\n'+)* ;

math : expression* ;

expression
    : LBRACE expression* RBRACE # BracedExp
    | LPAREN expression* RPAREN # ParenExp
    | LSQUARE expression* RSQUARE # SquareExp
    | DOT expression # DotExp
    | expression PERIOD expression # SubscriptExp
    | expression CARET expression # SuperscriptExp
    | expression FORWARDSLASH expression # DivExp
    | SQRT expression # SqrtExp
    | operator # OperatorExp
    | identifier # IdentifierExp
    | number # NumberExp
    | greek # GreekExp
    ;

operator : OPERATOR+ ;
identifier : IDENTIFIER ;
number : NUMBER ;

greek : GREEK+ ;

GREEK : 'del'
      | 'alpha'
      | 'beta'
      | 'gamma'
      | 'delta'
      | 'Delta'
      ;


CARET : '^' ;
LPAREN : '(' ;
RPAREN : ')' ;
LSQUARE : '[' ;
RSQUARE : ']' ;
LBRACE : '{' ;
RBRACE : '}' ;
OPERATOR : '+' | '-' | '=' | '∂' | 'Δ' ;
FORWARDSLASH : '/' ;

DOT : 'dot' ;
SQRT : 'sqrt' ;

IDENTIFIER : [a-zA-Z]+ ;

PERIOD : '.' ;

NUMBER : [0-9]+('.' [0-9]+)? ;
WS : [ \t\r\n]+ -> skip ;
