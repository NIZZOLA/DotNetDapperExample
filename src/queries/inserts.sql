
insert into Cargo
  (nomedocargo, ismanager )
  values
    ( 'Desenvolvedor',0 ),
	( 'Gerente' ,1),
	( 'Squad Leader',0 ),
	( 'P.O.' ,0),
	( 'Q.A.' ,0),
	( 'Scruum Master' ,0),
	( 'Desenvolvedor',0 )

insert into equipe ( nome )
   values ( 'Delorean' ),
		  ( 'Mandalorean' ),
		  ( 'Stark' ),
		  ( 'Avengers' ),
		  ( 'Marvel' )
 
 select * from equipe

 select * from cargo

 select * from funcionario

 insert into funcionario 
    (nome, cpf, rg, sexo, nascimento, superiorimediatoid, timeid, cargoid )
 values


 SELECT fun.id FUN_ID,
		fun.*, 
		cg.id  CG_ID,
		CG.*,
		TM.ID  TM_ID,
		TM.*,
		SUP.ID SUP_ID,
		SUP.*

	FROM funcionario fun
	INNER JOIN cargo   cg			ON cg.id = fun.cargoid
	INNER JOIN equipe  tm			ON tm.id = fun.timeid 
	INNER JOIN funcionario sup		ON sup.id = fun.superiorimediatoid 
	

	SELECT fun.id FUN_ID,
		fun.*, 
		cg.id  CG_ID,
		CG.*
		
	FROM funcionario fun
	INNER JOIN cargo   cg			ON cg.id = fun.cargoid
	

