<script setup lang="ts">
import type { ChallengeResponse, GameResponse } from '@/clients/apiClients/models';
import GameSelect from '@/components/GameSelect.vue';
import { createClient } from '@/services/apiClientFactory';
import { onMounted, ref } from 'vue';

const props = defineProps<{
  id: string;
}>();

const loading = ref(false);
const gamesLoading = ref(false);

const client = createClient();
const challenge = ref<ChallengeResponse | undefined>(undefined);
const games = ref<GameResponse[] | undefined>(undefined);

const headers = [
  { title: 'Status', key: 'status', sortable: true },
  { title: 'Name', key: 'name', sortable: true },
  { title: 'Year', key: 'year', sortable: true },
];

const statusOptions = [
  { title: 'Pas commencé', value: 'Pas commencé' },
  { title: 'En cours', value: 'En cours' },
  { title: 'Abandonné', value: 'Abandonné' },
  { title: 'Terminé', value: 'Terminé' },
];

onMounted(async () => {
  await loadChallenge();
  loadGames();
});

const loadChallenge = async () => {
  loading.value = true;
  challenge.value = await client.api.challenges.byChallengeId(props.id).get();
  loading.value = false;
};

const loadGames = async () => {
  gamesLoading.value = true;
  games.value = await client.api.challenges.byChallengeId(props.id).games.get();
  gamesLoading.value = false;
};

const addGame = async () => {
  games.value?.push({
    name: null,
    year: null,
    status: 'Pas commencé',
  });
};

const updateGame = async (game: GameResponse) => {
  if (game.shortId == null) {
    // If the game does not have a shortId, it means it's a new game that hasn't been saved yet.
    await client.api.challenges.byChallengeId(props.id).games.post({
      year: game.year,
    });
    return;
  }

  await client.api.challenges.byChallengeId(props.id).games.byGameId(game.shortId!).put({
    name: game.name,
    year: game.year,
    status: game.status,
  });
};
</script>

<template>
  <game-select />

  <v-data-table
    v-if="!loading && challenge"
    :items="games"
    :headers="headers"
    :loading="gamesLoading"
    no-data-text="Aucun challenge n'a été créé pour le moment."
    hide-default-footer
  >
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title> {{ challenge.username }} - {{ challenge.year }} </v-toolbar-title>

        <v-btn
          class="me-2"
          prepend-icon="mdi-plus"
          text="Add a game"
          border
          @click="addGame"
        ></v-btn>
      </v-toolbar>
    </template>

    <template #[`item.name`]="{ item }">
      <v-inline-select-field
        v-model="item.name"
        hide-cancel-icon
        hide-save-icon
        @blur="updateGame(item)"
      ></v-inline-select-field>
    </template>

    <template #[`item.year`]="{ item }">
      <v-inline-text-field
        v-model="item.year"
        hide-cancel-icon
        hide-save-icon
        @blur="updateGame(item)"
      ></v-inline-text-field>
    </template>

    <template #[`item.status`]="{ item }">
      <v-inline-select
        v-model="item.status"
        :items="statusOptions"
        item-title="title"
        item-value="value"
        hide-cancel-icon
        hide-save-icon
        required
        @blur="updateGame(item)"
      ></v-inline-select>
    </template>
  </v-data-table>
  <div v-else-if="!loading">
    <p>Ce challenge n'existe pas.</p>
  </div>
</template>
