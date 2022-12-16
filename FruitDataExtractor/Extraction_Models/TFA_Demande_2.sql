-- fic1
select c.codeptf, codesptf, c.CodeStatut, en.codeentite, coderegime, numcontrat, numsouscontrat, numaffiliation, nom, prenom, a1.montant as ass2023,	
    er1.cotisationannuelle as cot2023, er1.montant as montantannuel2023, e1.montant as montant202301	
    , a2.montant as ass2022, er3.deb2022, er3.fin2022, er3.cotisationannuelle as cot2022,  er3.montant as montantannuel2022, er3.montant202212	,
    a2.montant / a1.montant as rapport_ass_2022_2023, er3.cotisationannuelle / er1.cotisationannuelle as rapport_cotis_2022_2023, ((a1.montant / a2.montant) * (er3.montant202212)) - e1.montant as diff_1222_0123
from echeancier er1	
join assiette a1 on a1.codeassiette = 'FSS' and a1.datedebutass = '20230101'	
join assiette a2 on a2.codeassiette = 'FSS' and a2.datedebutass = '20220101'	
join echeance e1 on e1.idecheancier = er1.idecheancier and datedebutecheance = '2023-01-01'	
join affiliation a on a.idaffiliation = er1.idAffiliation	
join contrat c on c.idcontrat = a.idcontrat 	
join membre m on m.idaffiliation = a.idaffiliation and ouvrantdroit = 'O'	
join personne pe on pe.idpersonne = m.idpersonne 
join portefeuille po on po.codeptf = c.CodePTF
join entite en on en.codeentite = po.CodeEntite	
left outer join (select ermax.idaffiliation, max2022, er2.cotisationannuelle, er2.montant, er2.datedebutecheancier as deb2022, er2.datefinecheancier as fin2022, 	
                    e2.montant as montant202212	
from (select idaffiliation, max(idecheancier) as max2022 from echeancier where numecheancier between 20220001 and 20229999 group by idaffiliation) ermax 	
	join echeancier er2 on ermax.max2022 = er2.idecheancier
    join echeance e2 on e2.idecheancier = er2.idecheancier and datedebutecheance = '2022-12-01') er3 	
on er3.idaffiliation = a.idaffiliation 	
where er1.numecheancier = 20230001;

-- fic2
select c.codeptf, codesptf, c.CodeStatut, en.codeentite, coderegime, numcontrat, numsouscontrat, numaffiliation, nom, prenom, a1.montant as ass2023,	
    er3.cotisationannuelle as cot2023, er3.montant as montantannuel2023, er3.montant202301 as montant202301	
    , a2.montant as ass2022, er1.datedebutecheancier as deb2022, er1.datefinecheancier as fin2022, er1.cotisationannuelle as cot2022,  er1.montant as montantannuel2022,
    e1.montant as montant202212	
from (select idaffiliation, max(idecheancier) as max2022 from echeancier where numecheancier between 20220001 and 20229999 group by idaffiliation) ermax 	
join echeancier er1 on ermax.max2022 = er1.idecheancier
join echeance e1 on e1.idecheancier = er1.idecheancier and datedebutecheance = '2022-12-01'
join assiette a1 on a1.codeassiette = 'FSS' and a1.datedebutass = '20230101'	
join assiette a2 on a2.codeassiette = 'FSS' and a2.datedebutass = '20220101'	
join affiliation a on a.idaffiliation = ermax.idAffiliation	
join contrat c on c.idcontrat = a.idcontrat 	
join membre m on m.idaffiliation = a.idaffiliation and ouvrantdroit = 'O'	
join personne pe on pe.idpersonne = m.idpersonne 
join portefeuille po on po.codeptf = c.CodePTF
join entite en on en.codeentite = po.CodeEntite	
left outer join (select er2.idaffiliation, er2.numecheancier, er2.cotisationannuelle, er2.montant, e2.montant as montant202301
    from echeancier er2 
    join echeance e2 on e2.idecheancier = er2.idecheancier and datedebutecheance = '2023-01-01' and er2.numecheancier = 20230001) er3 	
on er3.idaffiliation = a.idaffiliation ;