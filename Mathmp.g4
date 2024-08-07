grammar Mathmp ;

file : (math '\n')* ;

math : expression* ;

expression
    : LBRACE expression* RBRACE
    | expression PERIOD expression
    | expression FORWARDSLASH expression
    | DOT expression
    | SQRT expression
    | operator
    | identifier
    | number
    ;

operator : OPERATOR ;
identifier : IDENTIFIER ;
number : NUMBER ;

LBRACE : '{' ;
RBRACE : '}' ;
OPERATOR : '+' | '-' | '(' | ')' | '=' ;
FORWARDSLASH : '/' ;

DOT : 'dot' ;
SQRT : 'sqrt' ;

IDENTIFIER : [a-zA-Z] ;

PERIOD : '.' ;

NUMBER : [0-9]+('.' [0.9]+) ;
