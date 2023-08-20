import { createRouter, createWebHistory } from "vue-router";
import HomeVue from "@/components/Home.vue";
import Category from "@/components/Category.vue";
import AboutVue from "@/components/About.vue";
import ErrorVue from "@/components/Error.vue";
import CreateCategory from "@/components/Category/CreateCategory.vue";
import EditCategory from "@/components/Category/EditCategory.vue";
import DeleteCategory from "@/components/Category/DeleteCategory.vue";
const routes = [
  {
    path: "/",
    component: HomeVue,
  },
  {
    path: "/category",
    component: Category,
  },
  {
    path: "/category/create",
    component: CreateCategory,
  },
  {
    path: "/category/edit/:id",
    component: EditCategory,
  },
  {
    path: "/category/delete/:id",
    component: DeleteCategory,
  },
  {
    path: "/about",
    component: AboutVue,
  },
  {
    path: "/:pathMatch(.*)*",
    component: ErrorVue,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});
export default router;
