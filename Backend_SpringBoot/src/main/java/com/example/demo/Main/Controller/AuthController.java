package com.example.demo.Main.Controller;


import com.example.demo.Main.Entity.User;
import com.example.demo.Main.Service.AuthService;
import com.example.demo.Main.Service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Optional;

@RestController
@RequestMapping("/api/auth")
public class AuthController {
    @Autowired
    private UserService userService;

    @Autowired
    private PasswordEncoder passwordEncoder;
    @Autowired
    private AuthService authService;


    // Register
    @PostMapping("/register")
    public ResponseEntity<?> registerUser(@RequestBody User user) {
        try{

        User RegisteredUser = authService.register(user);
        return ResponseEntity.ok(RegisteredUser);

    } catch (Exception e) {
        return ResponseEntity.badRequest().body(e.getMessage());
    }
    }



    // Login a user (example with basic username/password validation)
    @PostMapping("/login")
    public ResponseEntity<String> loginUser(@RequestBody User loginRequest) {
        Optional<User> user = userService.findByEmail(loginRequest.getEmail());

        if (user.isPresent() && passwordEncoder.matches(loginRequest.getPassword(), user.get().getPassword())) {
            // If authentication is successful, you can generate JWT here (if using JWT)
            String token = authService.login(loginRequest.getEmail(), loginRequest.getPassword());
            return ResponseEntity.ok(token);
        } else {
            return ResponseEntity.status(401).body("Invalid credentials");
        }
    }

}
