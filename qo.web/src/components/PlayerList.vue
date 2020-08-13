<template>
      <div class="border border-gray-800 rounded-lg p-20 mx-10 -mb-10 font-serif">
        The qualifying offer is a one-year contract, the value of which is calculated by averaging the highest {{ topQuantity }} player salaries from the prior season.
        {{ excludedPlayers.length }} players could not be considered in this calculation due to missing salary data for the previous season.
      </div>
</template>

<script>
export default {
    props: {
      includedPlayers: {
        type: Array
      },
      excludedPlayers: {
        type: Array
      },
      topQuantity: {
        type: Number
      }
    },
    computed: {
    }
}
</script>