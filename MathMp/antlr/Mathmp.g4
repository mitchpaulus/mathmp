grammar Mathmp ;

file : (math '\n'+)* ;

math : expression* ;

expression
    : LBRACE expression* RBRACE # BracedExp
    | LPAREN expression* RPAREN # ParenExp
    | LSQUARE expression* RSQUARE # SquareExp
    | DOT expression # DotExp
    | expression SQUARED # SquaredExp
    | expression PERIOD expression # SubscriptExp
    | expression CARET expression # SuperscriptExp
    | expression FORWARDSLASH expression # DivExp
    | SQRT expression # SqrtExp
    | operator # OperatorExp
    | abbrev # AbbrevExp
    | SINGLE_QUOTE_STR # SingleQuoteStrExp
    | STRING # StringExp
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
      | 'rho'
      | 'nu'
      | 'eta'
      ;

APPROX : 'approx' ;
CDOT : 'cdot' ;

abbrev : APPROX | CDOT ;

SQUARED : '²' ;

CARET : '^' ;
LPAREN : '(' ;
RPAREN : ')' ;
LSQUARE : '[' ;
RSQUARE : ']' ;
LBRACE : '{' ;
RBRACE : '}' ;
OPERATOR : '+' | '-' | '=' | '∂' | 'Δ' | '°' | ',' | '≈' ;
FORWARDSLASH : '/' ;

// See pg. 78 of Definitive ANTLR Reference.
STRING : '"' (ESC|.)*? '"' ;
fragment ESC : '\\"'  | '\\\\' ;

SINGLE_QUOTE_STR : '\'' [a-zA-Z] + ;

DOT : 'dot' ;
SQRT : 'sqrt' ;

IDENTIFIER : [a-zA-Z]+ ;

PERIOD : '.' ;

NUMBER : [0-9]+('.' [0-9]+)? ;
WS : [ \t\r\n]+ -> skip ;
