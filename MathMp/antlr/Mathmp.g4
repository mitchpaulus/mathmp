grammar Mathmp ;

file : (math '\n')* ;

math : expression* ;

expression
    : LBRACE expression* RBRACE # BracedExp
    | LPAREN expression RPAREN # ParenExp
    | DOT expression # DotExp
    | expression PERIOD expression # SubscriptExp
    | expression CARET expression # SuperscriptExp
    | expression FORWARDSLASH expression # DivExp
    | SQRT expression # SqrtExp
    | operator # OperatorExp
    | identifier # IdentifierExp
    | number # NumberExp
    ;

operator : OPERATOR ;
identifier : IDENTIFIER ;
number : NUMBER ;

CARET : '^' ;
LPAREN : '(' ;
RPAREN : ')' ;
LBRACE : '{' ;
RBRACE : '}' ;
OPERATOR : '+' | '-' | '(' | ')' | '=' ;
FORWARDSLASH : '/' ;

DOT : 'dot' ;
SQRT : 'sqrt' ;

IDENTIFIER : [a-zA-Z]+ ;

PERIOD : '.' ;

NUMBER : [0-9]+('.' [0.9]+) ;
WS : [ \t\r\n]+ -> skip ;
