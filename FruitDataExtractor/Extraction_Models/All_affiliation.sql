select    
ct.NumContrat,ct.NumSousContrat,aff.NumAffiliation,
per.Nom, per.Prenom,
cb.CodeCB,
aff.DateFinAffiliation
-- mb.*,  mbc.*,cb.*,   
from contrat ct  
join affiliation aff on ct.idContrat = aff.idContrat
join membre mb on aff.idAffiliation = mb.idAffiliation 
left join membrelien ml on mb.idMembre = ml.idMembre  
join membrecb mbc on mb.idMembre = mbc.idMembre  
join personne per on mb.idPersonne = per.idPersonne 
join cb on cb.CodeCB = mbc.CodeCB  
left join iban on mb.idPersonne = iban.idPersonne
where   CONCAT_WS('_', ct.NumContrat, ct.NumSousContrat) = '654746_00000';