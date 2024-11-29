package com.example.demo.Main.Service;


import com.example.demo.Main.Entity.Category;
import com.example.demo.Main.Repository.CategoryRepository;
import org.springframework.stereotype.Service;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;
import java.util.Optional;

@Service
public class CategoryService {

    @Autowired
    private CategoryRepository categoryRepository;




    public List<Category> getAllCategories() {
        return categoryRepository.findAll();
    }
    public Optional<Category> getCategoryById(String id) {
        return  categoryRepository.findById(id);
    }
    public Category addCategory(Category category) {
        return categoryRepository.save(category);
    }
    public Category updateCategory(String id, Category updatedCategory) {
        return categoryRepository.findById(id).map(category -> {
            category.setName(updatedCategory.getName());
            category.setDescription(updatedCategory.getDescription());
            return categoryRepository.save(category);
        }).orElse(null);

    }
    public void deleteCategory(String id) {
        categoryRepository.deleteById(id);
    }


}
