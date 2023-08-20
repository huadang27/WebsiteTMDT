<template>
  <div class="border p-3 mt-4">
    <div class="row pb-2">
      <h2 class="text-dark">Create Category</h2>
      <hr />
    </div>

    <form @submit.prevent="createCategory">
      <div class="mb-3 row p-1">
        <label for="Name" class="p-0">Name</label>
        <input v-model="category.name" id="Name" class="form-control" />
        <span class="text-danger" v-if="errors.name">{{ errors.name }}</span>
      </div>

      <div class="mb-3 row p-1">
        <label for="DisplayOrder" class="p-0">Display Order</label>
        <input
          v-model="category.displayOrder"
          id="DisplayOrder"
          type="number"
          class="form-control"
        />
        <span class="text-danger" v-if="errors.displayOrder">
          {{ errors.displayOrder }}
        </span>
      </div>

      <div class="row">
        <div class="col-6 col-md-3">
          <button type="submit" class="btn btn-dark form-control">Create</button>
        </div>
        <div class="col-6 col-md-3">
          <router-link
            to="/category"
            class="btn btn-outline-secondary form-control"
          >
            Go Back
          </router-link>
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      category: {
        name: "",
        displayOrder: 0,
      },
      errors: {},
    };
  },
  methods: {
    async createCategory() {
      this.errors = {}; // Clear errors before each validation
      if (!this.category.name) {
        this.errors.name = "Name is required.";
      }
      if (
        !this.category.displayOrder ||
        this.category.displayOrder < 0 ||
        this.category.displayOrder > 1100
      ) {
        this.errors.displayOrder =
          "Display Order is required and must be between 0 and 1100.";
      }

      if (Object.keys(this.errors).length === 0) {
        try {
          await axios.post(
            "https://localhost:7139/api/Category",
            this.category
          );
          this.$router.push("/category"); // redirect to the list
        } catch (error) {
          console.error(error);
        }
      }
    },
  },
};
</script>
