<script setup lang="ts">
import type { ChallengeResponse } from '@/clients/apiClients/models';
import { createClient } from '@/services/apiClientFactory';
import { onBeforeMount, onMounted, ref } from 'vue';

const props = defineProps<{
  id: string;
}>();

const loading = ref(false);
const challenges = ref<ChallengeResponse | undefined>(undefined);

onMounted(async () => {
  loading.value = true;
  const client = createClient();
  challenges.value = await client.api.challenges.byChallengeId(props.id).get();
  loading.value = false;
});
</script>

<template>
  <h2>Challenge</h2>

  <v-container v-if="!loading">
    <div v-if="challenges">
      <h3>{{ challenges.username }} - {{ challenges.year }}</h3>
    </div>
    <div v-else>
      <p>No challenge found.</p>
    </div>
  </v-container>
</template>
