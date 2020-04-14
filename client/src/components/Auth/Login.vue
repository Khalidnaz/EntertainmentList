<template>
  <v-container mt-5>
    <v-row justify="center">
      <h1>Welcome Back!</h1>
    </v-row>
    <v-card class="mx-auto mt-5" color="secondary" dark max-width="800">
      <v-form
        v-bind:value="isFormValid"
        lazy-validation
        ref="form"
        @submit.prevent="handleLogin"
      >
        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="emailRules"
              v-model="email"
              prepend-icon="mdi-face"
              label="Email Address"
              type="text"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="6">
            <v-text-field
              v-bind:rules="passwordRules"
              v-model="password"
              prepend-icon="mdi-lock"
              label="Password"
              type="text"
              required
            ></v-text-field>
          </v-col>
        </v-row>

        <v-row justify="center">
          <v-col cols="1">
            <v-progress-circular
							v-if='loading'
              indeterminate
              color="accent"
            ></v-progress-circular>
            <v-btn
							v-else
              v-bind:loading="loading"
              v-bind:disabled="!isFormValid || loading"
              color="accent"
              type="submit"
            >
              Sign in
            </v-btn>
          </v-col>
        </v-row>
        <v-row>
          <v-col col="6">
            <h3 class="text-center">
              Don't have an account?
              <router-link to="/register">Sign up</router-link>
            </h3>
          </v-col>
        </v-row>
      </v-form>
    </v-card>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'Login',
  computed: {
    ...mapGetters(['user', 'error', 'loading']),
    isFormValid() {
      return this.email.length > 0 && this.password.length > 0;
    }
  },
  data() {
    return {
      email: '',
      password: '',
      emailRules: [email => !!email || 'Email is required'],
      passwordRules: [password => !!password || 'Password is required']
    };
  },
  methods: {
    handleLogin() {
      if (this.$refs.form.validate()) {
        this.$store.dispatch('login', {
          email: this.email,
          password: this.password
        });
      }
    }
  }
};
</script>

<style></style>
