package com.example.demo.Main.Repository;

import com.example.demo.Main.Entity.User;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.Optional;

public interface UserRepository  extends MongoRepository<User, String> {
    Optional <User> findByUsername(String username);
    Optional <User> findByEmail(String email);
}
