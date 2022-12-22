CREATE TABLE userTable (
  id_user int AUTO_INCREMENT,
  first_name varchar(255) NOT NULL,
  last_name varchar(255) NOT NULL,
  email varchar(255) NOT NULL,
  user_password varchar(255) NOT NULL,
  address varchar(255) NOT NULL,
  postal_code varchar(255) NOT NULL,
  town varchar(255) NOT NULL,
  phone_number varchar(255) NOT NULL,
  admin tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY(id_user)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


CREATE TABLE customerOrder (
  id_customer_order int AUTO_INCREMENT,
  number_item_customer varchar(255) NOT NULL,
  order_customer varchar(255) NOT NULL,
  price_customer varchar(255) NOT NULL,
  price_without_tcc_customer varchar(255) NOT NULL,
  order_date_customer varchar(255) NOT NULL,
  discount_customer  varchar(255) NOT NULL,
  delivery_cost_customer   varchar(255) NOT NULL,
  order_item_id_customer varchar(255) NOT NULL,
  PRIMARY KEY(id_customer_order)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;