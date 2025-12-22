grammar Mathmp ;

file : ('\r'? '\n')* (math ('\r'? '\n')+)* ;

math : expression* ;

expression
    : LBRACE expression* RBRACE # BracedExp
    | LPAREN expression* RPAREN # ParenExp
    | LSQUARE expression* RSQUARE # SquareExp
    | OpType=(DOT|HAT|BAR) expression # DotExp
    | expression SQUARED # SquaredExp
    | expression PERIOD expression # SubscriptExp
    | expression CARET expression # SuperscriptExp
    | expression FORWARDSLASH expression # DivExp
    | SQRT expression # SqrtExp
    | SUM LBRACE expression RBRACE LBRACE expression RBRACE # SumExp
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

SUM : 'sum' ;

GREEK : 'del'
      | 'alpha'
      | 'beta'
      | 'gamma'
      | 'delta'
      | 'Delta'
      | 'rho'
      | 'nu'
      | 'eta'
      | 'omega'
      | 'Sigma'
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
OPERATOR : '+' | '-' | '=' | '∂' | 'Δ' | '°' | ',' | '≈' | '⋅' ;
FORWARDSLASH : '/' ;

// See pg. 78 of Definitive ANTLR Reference.
STRING : '"' (ESC|.)*? '"' ;
fragment ESC : '\\"'  | '\\\\' ;

// For very simple text
SINGLE_QUOTE_STR : '\'' [a-zA-Z] + ;

DOT : 'dot' ;
HAT : 'hat' ;
BAR : 'bar' ;
SQRT : 'sqrt' ;

IDENTIFIER : [a-zA-Z]+ ;

PERIOD : '.' ;

NUMBER : [0-9]+('.' [0-9]+)? ;
WS : [ \t]+ -> skip ;

COMMENT : '//' ~[\r\n]* -> skip ;
