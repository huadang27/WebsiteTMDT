<template>
  <div class="border p-3 mt-4">
    <h2 class="text-dark">Create Category</h2>
    <hr />

    <div class="mb-3 row p-1">
      <label for="Name" class="p-0">Name</label>
      <input v-model="category.name" id="Name" class="form-control" />
    </div>

    <div class="mb-3 row p-1">
      <label for="DisplayOrder" class="p-0">Display Order</label>
      <input
        v-model="category.displayOrder"
        id="DisplayOrder"
        type="number"
        class="form-control"
      />
    </div>

    <div class="row">
      <button
        @click="saveCategory"
        type="button"
        class="btn btn-dark form-control"
      >
        Update
      </button>
      <button
        @click="goBack"
        type="button"
        class="btn btn-outline-secondary form-control"
      >
        Go Back
      </button>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "EditCategory",
  data() {
    return {
      category: {
        id: null,
        name: "",
        displayOrder: 0,
      },
    };
  },
  async created() {
    const response = await axios.get(
      `https://localhost:7139/api/category/${this.$route.params.id}`
    );
    this.category = response.data;
  },
  methods: {
    async saveCategory() {
      try {
        await axios.put(
          `https://localhost:7139/api/category/${this.category.id}`,
          this.category
        );
        this.$router.push("/category");
      } catch (error) {
        console.error(error);
      }
    },
    goBack() {
      this.$router.push("/category");
    },
  },
};
</script>
