package com.example.demo.Main.Repository;

import com.example.demo.Main.Entity.Product;
import org.springframework.data.mongodb.repository.MongoRepository;
public interface ProductRepository extends MongoRepository<Product, String> {


}
