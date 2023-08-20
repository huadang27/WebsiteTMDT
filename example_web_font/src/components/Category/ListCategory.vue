<template>
  <div class="container">
    <div class="row pt-4 pb-2">
      <div class="col-6">
        <h2 class="text-dark">Category List</h2>
      </div>
      <div class="col-6 text-end">
        <router-link to="/category/create" class="btn btn-primary">
          <i class="bi bi-plus-lg"></i> Create New Category
        </router-link>
      </div>
    </div>

    <table class="table table-bordered table-striped">
      <thead>
        <tr>
          <th>Name Category</th>
          <th>Display Order</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="category in categories" :key="category.id">
          <td>{{ category.name }}</td>
          <td>{{ category.displayOrder }}</td>
          <td>
            <div class="w-75 btn-group" role="group">
              <router-link
                :to="`/category/edit/${category.id}`"
                class="btn btn-success mx-2"
              >
                <i class="bi bi-pen"></i> Edit
              </router-link>

              <router-link
                :to="`/category/delete/${category.id}`"
                class="btn btn-danger"
              >
                <i class="bi bi-trash3"></i> Delete
              </router-link>
              <!-- <button
                class="btn btn-danger"
                @click="deleteCategory(category.id)"
              >
                <i class="bi bi-trash3"></i> Delete
              </button> -->
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ListCategory",
  data() {
    return {
      categories: [],
    };
  },
  created() {
    this.fetchCategories();
  },
  methods: {
    fetchCategories() {
      axios
        .get("https://localhost:7139/api/Category")
        .then((response) => {
          this.categories = response.data;
        })
        .catch((error) => {
          console.error("There was an error!", error);
        });
    },
    deleteCategory(id) {
      axios
        .delete(`https://localhost:7139/api/Category/${id}`)
        .then(() => {
          // Refresh the category list
          this.fetchCategories();
        })
        .catch((error) => {
          console.error("There was an error!", error);
        });
    },
  },
};
</script>
