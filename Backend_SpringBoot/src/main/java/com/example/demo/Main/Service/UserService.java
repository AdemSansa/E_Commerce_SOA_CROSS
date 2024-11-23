package com.example.demo.Main.Service;

import com.example.demo.Main.Entity.User;
import com.example.demo.Main.Repository.UserRepository;
import com.example.demo.Main.Security.SecurityConfig;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.Optional;


@Service
public class UserService {


    @Autowired
    private UserRepository userRepository;

    @Autowired
    private SecurityConfig bCryptPasswordEncoder;


    //Register User
    public User registerUser(User user) {
        user.setPassword(bCryptPasswordEncoder.passwordEncoder().encode(user.getPassword()));


        return userRepository.save(user);
    }
    // Find user by username
    public Optional<User> findByUsername(String username) {
        return userRepository.findByUsername(username);
    }


}
