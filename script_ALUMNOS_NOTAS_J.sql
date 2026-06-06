CREATE TABLE ALUMNOS_NOTAS_J (
    ID NUMBER GENERATED ALWAYS AS IDENTITY,
    NOMBRE VARCHAR2(100),
    NOTA1 NUMBER(5,2),
    NOTA2 NUMBER(5,2),
    NOTA3 NUMBER(5,2),
    NOTA4 NUMBER(5,2),
    NOTA5 NUMBER(5,2),
    SUMA NUMBER(8,2),
    PROMEDIO NUMBER(8,2),
    FECHA_REGISTRO DATE DEFAULT SYSDATE,
    CONSTRAINT PK_ALUMNOS_J PRIMARY KEY(ID)
);

COMMIT;

-- probar el límite de 87 alumnos .
BEGIN
    FOR i IN 1..85 LOOP

        INSERT INTO ALUMNOS_NOTAS_J
        (
            NOMBRE,
            NOTA1,
            NOTA2,
            NOTA3,
            NOTA4,
            NOTA5,
            SUMA,
            PROMEDIO
        )
        VALUES
        (
            'ALUMNO ' || LPAD(i, 3, '0'),

            ROUND(DBMS_RANDOM.VALUE(1, 5), 2),
            ROUND(DBMS_RANDOM.VALUE(1, 5), 2),
            ROUND(DBMS_RANDOM.VALUE(1, 5), 2),
            ROUND(DBMS_RANDOM.VALUE(1, 5), 2),
            ROUND(DBMS_RANDOM.VALUE(1, 5), 2),

            0,
            0
        );

    END LOOP;

    COMMIT;
END;
/

COMMIT;

-- script para calcular correctamente la SUMA y el PROMEDIO de los 85 registros .
UPDATE ALUMNOS_NOTAS_J
SET
    SUMA =
          NOTA1
        + NOTA2
        + NOTA3
        + NOTA4
        + NOTA5,

    PROMEDIO =
        ROUND(
            (
                NOTA1
              + NOTA2
              + NOTA3
              + NOTA4
              + NOTA5
            ) / 5,
            2
        );

COMMIT;

-- verificar la carga .
SELECT COUNT(*) TOTAL_ALUMNOS FROM ALUMNOS_NOTAS_J;

