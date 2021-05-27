insert into funcionario 
    (nome, cpf, rg, sexo, nascimento, superiorimediatoid, timeid, cargoid )
 values

--	('DARTH SIDIOUS', '111111111', '22222222', 1, '01/01/1900', null, 1, 3),
--	('DARTH VADER', '33333441111', '22222222', 1, '01/01/1930', 2, 1, 4),
	('DARTH MAUL', '99333441111', '99222222', 1, '01/01/1930', 2, 1, 2),



SELECT * FROM FUNCIONARIO
select * from cargo



SELECT EQ.ID EQ_ID,
		EQ.*,
		FUN.ID FUN_ID,
		FUN.*
		FROM EQUIPE EQ 
		INNER JOIN FUNCIONARIO FUN ON FUN.TIMEID = EQ.ID 


select * from cargo


select * from equipe

select * from funcionario