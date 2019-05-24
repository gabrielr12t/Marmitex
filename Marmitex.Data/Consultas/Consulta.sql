

-- drop DATABASE Marmitex

--  DELETE from Pedidos where Id = 4
--  DELETE from Pedidos where Id = 5
--  DELETE from Pedidos where Id = 6
--  DELETE from Pedidos where Id = 7
--  DELETE from Pedidos where Id = 8

--   DELETE from Marmitas where Id = 4
--   DELETE from Marmitas where Id = 5
--   DELETE from Marmitas where Id = 6
--   DELETE from Marmitas where Id = 7
--DELETE from Pedidos where Id = 9
 
update Pedidos set [Data] = '2019-05-17 04:45:22.6554645' where Id = 2

SELECT * FROm Pedidos
 

-- SELECT p.Id, p.[Data], p.OpcaoEntrega, p.OpcaoPagamento, p.Total,
--     mis.Nome mistura, m.Observacao, m.SaladaId, m.Tamanho, m.Valor
-- FROM Pedidos p
--     INNER JOIN ItensPedidos ip on p.Id = ip.PedidoId
--     INNER JOIN Marmitas m on m.Id = ip.MarmitaId
--     INNER JOIN Misturas mis on mis.Id = m.MisturaId
 
 