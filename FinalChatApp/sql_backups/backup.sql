PGDMP     7    ;                z           ReactChatApp    14.2    14.2 
    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                        0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16439    ReactChatApp    DATABASE     c   CREATE DATABASE "ReactChatApp" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.UTF-8';
    DROP DATABASE "ReactChatApp";
                postgres    false                       0    0    DATABASE "ReactChatApp"    ACL     .   GRANT ALL ON DATABASE "ReactChatApp" TO zack;
                   postgres    false    3586            �            1259    24662    messages    TABLE     �   CREATE TABLE public.messages (
    id integer NOT NULL,
    username character varying(255) NOT NULL,
    message character varying(255) NOT NULL,
    date_time timestamp without time zone DEFAULT now()
);
    DROP TABLE public.messages;
       public         heap    postgres    false            �            1259    24661    messages_id_seq    SEQUENCE     �   CREATE SEQUENCE public.messages_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.messages_id_seq;
       public          postgres    false    210                       0    0    messages_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.messages_id_seq OWNED BY public.messages.id;
          public          postgres    false    209            n           2604    24665    messages id    DEFAULT     j   ALTER TABLE ONLY public.messages ALTER COLUMN id SET DEFAULT nextval('public.messages_id_seq'::regclass);
 :   ALTER TABLE public.messages ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    210    209    210            q           2606    24670    messages messages_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.messages
    ADD CONSTRAINT messages_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.messages DROP CONSTRAINT messages_pkey;
       public            postgres    false    210           