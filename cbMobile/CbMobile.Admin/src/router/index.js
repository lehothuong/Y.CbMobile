import Vue from "vue";
import Router from "vue-router";

Vue.use(Router);

import Layout from "@/layout";

export const constantRoutes = [
  {
    path: "/login",
    component: () => import("@/views/login/index"),
    hidden: true
  },
  {
    path: "/auth-redirect",
    component: () => import("@/views/login/auth-redirect"),
    hidden: true
  },
  {
    path: "/404",
    component: () => import("@/views/error-page/404"),
    hidden: true
  },
  {
    path: "/401",
    component: () => import("@/views/error-page/401"),
    hidden: true
  },
  {
    path: "/",
    component: Layout,
    redirect: "/dashboard",
    children: [
      {
        path: "dashboard",
        component: () => import("@/views/dashboard/index"),
        name: "Dashboard",
        meta: { title: "Dashboard", icon: "dashboard", affix: true }
      }
    ]
  }
];

export const asyncRoutes = [
  {
    path: "/permission",
    component: Layout,
    redirect: "/permission/page",
    alwaysShow: true, // will always show the root menu
    name: "Permission",
    meta: {
      title: "Permission",
      icon: "lock",
      roles: ["admin", "editor"] // you can set roles in root nav
    },
    children: [
      {
        path: "page",
        component: () => import("@/views/permission/page"),
        name: "PagePermission",
        meta: {
          title: "Page Permission",
          roles: ["admin"] // or you can only set roles in sub nav
        }
      },
      {
        path: "directive",
        component: () => import("@/views/permission/directive"),
        name: "DirectivePermission",
        meta: {
          title: "Directive Permission"
          // if do not set roles, means: this page does not require permission
        }
      },
      {
        path: "role",
        component: () => import("@/views/permission/role"),
        name: "RolePermission",
        meta: {
          title: "Role Permission",
          roles: ["admin"]
        }
      }
    ]
  },

  {
    path: "/category-product",
    component: Layout,
    redirect: "/category-product/list",
    name: "CategoryProduct",
    meta: {
      title: "CategoryProduct",
      icon: "example"
    },
    children: [
      {
        path: "create",
        component: () => import("@/views/category-product/create"),
        name: "CreateCategoryProduct",
        meta: { title: "Create", icon: "edit" }
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/category-product/edit"),
        name: "EditCategoryProduct",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/category-product/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/category-product/list"),
        name: "ListCategoryProduct",
        meta: { title: "List", icon: "list" }
      }
    ]
  },
  {
    path: "/main-memory",
    component: Layout,
    redirect: "/main-memory/list",
    name: "MainMemory",
    meta: {
      title: "MainMemory",
      icon: "example"
    },
    children: [
      {
        path: "create",
        component: () => import("@/views/main-memory/create"),
        name: "CreateMainMemory",
        meta: { title: "Create", icon: "edit" }
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/main-memory/edit"),
        name: "EditMainMemory",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/main-memory/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/main-memory/list"),
        name: "ListMainMemory",
        meta: { title: "List", icon: "list" }
      }
    ]
  },

  {
    path: "/manufacturer",
    component: Layout,
    redirect: "/manufacturer/list",
    name: "Manufacturer",
    meta: {
      title: "Manufacturer",
      icon: "example"
    },
    children: [
      {
        path: "create",
        component: () => import("@/views/manufacturer/create"),
        name: "CreateManufacturer",
        meta: { title: "Create", icon: "edit" }
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/manufacturer/edit"),
        name: "EditManufacturer",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/manufacturer/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/manufacturer/list"),
        name: "ListManufacturer",
        meta: { title: "List", icon: "list" }
      }
    ]
  },

  {
    path: "/product",
    component: Layout,
    redirect: "/product/list",
    name: "Product",
    meta: {
      title: "Product",
      icon: "example"
    },
    children: [
      {
        path: "create",
        component: () => import("@/views/product/create"),
        name: "CreateProduct",
        meta: { title: "Create", icon: "edit" }
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/product/edit"),
        name: "EditProduct",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/product/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/product/list"),
        name: "ListProduct",
        meta: { title: "List", icon: "list" }
      }
    ]
  },
  {
    path: "/banner",
    component: Layout,
    redirect: "/banner/list",
    name: "Banner",
    meta: {
      title: "Banner",
      icon: "example"
    },
    children: [
      {
        path: "create",
        component: () => import("@/views/banner/create"),
        name: "CreateBanner",
        meta: { title: "Create", icon: "edit" }
      },
      {
        path: "edit/:id(\\d+)",
        component: () => import("@/views/banner/edit"),
        name: "EditBanner",
        meta: {
          title: "Edit",
          noCache: true,
          activeMenu: "/banner/list"
        },
        hidden: true
      },
      {
        path: "list",
        component: () => import("@/views/banner/list"),
        name: "ListBanner",
        meta: { title: "List", icon: "list" }
      }
    ]
  },
  { path: "*", redirect: "/404", hidden: true }
];

const createRouter = () =>
  new Router({
    // mode: 'history', // require service support
    scrollBehavior: () => ({ y: 0 }),
    routes: constantRoutes
  });

const router = createRouter();

// Detail see: https://github.com/vuejs/vue-router/issues/1234#issuecomment-357941465
export function resetRouter() {
  const newRouter = createRouter();
  router.matcher = newRouter.matcher; // reset router
}

export default router;
