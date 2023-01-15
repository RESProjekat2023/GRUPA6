DROP TABLE brojilo CASCADE CONSTRAINTS;

DROP TABLE potrosnja_brojila CASCADE CONSTRAINTS;

CREATE TABLE brojilo (
    id_brojila                 INTEGER NOT NULL,
    ime_korisnika              VARCHAR2(32 CHAR) NOT NULL,
    prezime_korisnika          VARCHAR2(32 CHAR) NOT NULL,
    ulica                      VARCHAR2(32 CHAR) NOT NULL,
    broj                       NUMBER(10, 2) NOT NULL,
    postanski_broj             NUMBER(10, 2) NOT NULL,
    grad                       VARCHAR2(32 CHAR) NOT NULL,
        CONSTRAINT brojilo_PK PRIMARY KEY (id_brojila)
);



CREATE TABLE potrosnja_brojila (
    id_brojila                 INTEGER NOT NULL,
    id_potrosnja               INTEGER NOT NULL,
    potrosnja                  INTEGER NOT NULL,
    mesec                      INTEGER NOT NULL,
	 CONSTRAINT potrosnja_brojila_PK PRIMARY KEY (id_potrosnja, id_brojila),
	 CONSTRAINT potrosnja_brojila_FK FOREIGN KEY (id_brojila) REFERENCES brojilo(id_brojila),
         CINSTRAINT potrosnja_CH CHECK (mesec<13 and mesec>0)
);
