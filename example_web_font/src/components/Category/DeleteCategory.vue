<template>
  <div class="border p-3 mt-4">
    <div class="row pb-2">
      <h2 class="text-dark">Delete Category</h2>
      <hr />
    </div>
    <div class="mb-3 row p-1">
      <label>Name</label>
      <input disabled class="form-control" v-model="category.name" />
    </div>
    <div class="mb-3 row p-1">
      <label>Display Order</label>
      <input disabled class="form-control" v-model="category.displayOrder" />
    </div>
    <div class="row">
      <div class="col-6 col-md-3">
        <button
          type="submit"
          class="btn btn-dark form-control"
          @click="deleteCategory"
        >
          Delete
        </button>
      </div>
      <div class="col-6 col-md-3">
        <router-link
          to="/category"
          class="btn btn-outline-secondary form-control"
        >
          Back
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "DeleteCategory",
  data() {
    return {
      category: {
        id: null,
        name: "",
        displayOrder: null,
      },
    };
  },
  created() {
    this.fetchCategory();
  },
  methods: {
    fetchCategory() {
      const id = this.$route.params.id;
      axios
        .get(`https://localhost:7139/api/Category/${id}`)
        .then((response) => {
          this.category = response.data;
        })
        .catch((error) => {
          console.error("There was an error!", error);
        });
    },
    deleteCategory() {
      axios
        .delete(`https://localhost:7139/api/Category/${this.category.id}`)
        .then(() => {
          // Navigate back to the category list
          this.$router.push("/category");
        })
        .catch((error) => {
          console.error("There was an error!", error);
        });
    },
  },
};
</script>
