CREATE  TABLE skucode_order (
    skucode VARCHAR(255),
    sort_order INT
);


INSERT INTO skucode_order (skucode, sort_order)
VALUES
    ('2071219091' , 1),
    ('2071220851', 2),
    ('2071220868', 3),
    ('2071220875', 4),
    ('2727549992', 5),
    ('2727549985', 6),
    ('2727550028', 7),
    ('2727550011', 8),
    ('2071225184', 9),
    ('2071225191', 10),
    ('2071224293', 11),
    ('896555789', 12);

	SELECT s.*
FROM skucode_order o
JOIN sku s ON o.skucode = s.skucode
ORDER BY o.sort_order;
