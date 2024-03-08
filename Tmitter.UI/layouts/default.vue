<script setup lang="ts">
import LeftSideBar from "~/components/theme/LeftSideBar.vue";
import MainContent from "~/components/theme/MainContent.vue";
import RightSideBar from "~/components/theme/RightSideBar.vue";
</script>

<template>
  <div class="lg:container mx-auto font-poppins text-slate-600">
    <div class="grid grid-cols-12">
      <LeftSideBar class="hidden md:block col-span-2 lg:col-span-2 bg-yellow-300 p-2"/>
      <MainContent class="col-span-12 md:col-span-10 lg:col-span-8 bg-red-200 p-2"/>
      <RightSideBar class="hidden lg:block lg:col-span-2 bg-green-300 p-2"/>
    </div>
  </div>
</template>

<style scoped>

</style>